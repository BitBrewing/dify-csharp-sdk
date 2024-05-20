using DifyAI.ObjectModels;
using Microsoft.Extensions.Options;
using MimeMapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI
{
    internal static class HttpClientExtensions
    {
        const string JsonContentType = "application/json";

        private static readonly JsonSerializerOptions _defaultSerializerOptions = new()
        {
            WriteIndented = false,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            NumberHandling = JsonNumberHandling.AllowReadingFromString, // 有些数字型的dify返回为字符串
        };

        public static void AddAuthorization(this HttpClient httpClient, string apiKey)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"Bearer {apiKey}");
            }
        }

        private static async Task ValidateResponseAsync(this HttpResponseMessage responseMessage, CancellationToken cancellationToken)
        {
            if (!responseMessage.IsSuccessStatusCode)
            {
                if (IsJsonContentType(responseMessage))
                {
                    var error = await responseMessage.Content.ReadFromJsonAsync<Error>(_defaultSerializerOptions, cancellationToken);
                    throw new DifyAIException(error.Code, error.Message, error.Status);
                }
                else
                {
                    throw new HttpRequestException($"Response status code does not indicate success: {(int)responseMessage.StatusCode} ({responseMessage.ReasonPhrase}).");
                }
            }
        }

        public static async Task<T> GetAsAsync<T>(this HttpClient httpClient, string requestUri, IRequest requestModel, CancellationToken cancellationToken)
        {
            httpClient.AddAuthorization(requestModel.ApiKey);

            using var responseMessage = await httpClient.GetAsync(requestUri, cancellationToken);

            await responseMessage.ValidateResponseAsync(cancellationToken);

            return await responseMessage.Content.ReadFromJsonAsync<T>(_defaultSerializerOptions, cancellationToken);
        }

        private static async Task<HttpResponseMessage> PostCoreAsync(this HttpClient httpClient, string requestUri, IRequest requestModel, CancellationToken cancellationToken)
        {
            httpClient.AddAuthorization(requestModel.ApiKey);

            using var content = JsonContent.Create(requestModel, requestModel.GetType(), null, _defaultSerializerOptions);
            var responseMessage = await httpClient.PostAsync(requestUri, content, cancellationToken);

            await responseMessage.ValidateResponseAsync(cancellationToken);

            return responseMessage;
        }

        public static async Task PostAsync(this HttpClient httpClient, string requestUri, IRequest requestModel, CancellationToken cancellationToken)
        {
            using var responseMessage = await httpClient.PostCoreAsync(requestUri, requestModel, cancellationToken);
        }

        public static async Task<T> PostAsAsync<T>(this HttpClient httpClient, string requestUri, IRequest requestModel, CancellationToken cancellationToken)
        {
            using var responseMessage = await httpClient.PostCoreAsync(requestUri, requestModel, cancellationToken);

            return await responseMessage.Content.ReadFromJsonAsync<T>(_defaultSerializerOptions, cancellationToken);
        }

        public static async IAsyncEnumerable<T> PostChunkAsAsync<T>(this HttpClient httpClient, string requestUri, IRequest requestModel, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            httpClient.AddAuthorization(requestModel.ApiKey);

            using var content = JsonContent.Create(requestModel, requestModel.GetType(), null, _defaultSerializerOptions);
            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);

            requestMessage.Content = content;
            using var responseMessage = await httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

            await responseMessage.ValidateResponseAsync(cancellationToken);

            await using var stream = await responseMessage.Content.ReadAsStreamAsync(cancellationToken);

            using var reader = new StreamReader(stream);

            while (!reader.EndOfStream)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var line = await reader.ReadLineAsync();
                // Skip empty lines
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                line = line.RemoveIfStartWith("data: ");

                T block;
                try
                {
                    // When the response is good, each line is a serializable CompletionCreateRequest
                    block = JsonSerializer.Deserialize<T>(line, _defaultSerializerOptions);
                }
                catch (Exception)
                {
                    // When the API returns an error, it does not come back as a block, it returns a single character of text ("{").
                    // In this instance, read through the rest of the response, which should be a complete object to parse.
                    line += await reader.ReadToEndAsync();
                    block = JsonSerializer.Deserialize<T>(line, _defaultSerializerOptions);
                }

                if (null != block)
                {
                    yield return block;
                }
            }
        }

        //public static async Task DownloadChunkAsync(this HttpClient httpClient, string requestUri, IRequest requestModel, CancellationToken cancellationToken)
        //{
        //    httpClient.AddAuthorization(requestModel.ApiKey);

        //    using var content = JsonContent.Create(requestModel, requestModel.GetType(), null, _defaultSerializerOptions);
        //    using var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);

        //    requestMessage.Content = content;
        //    using var responseMessage = await httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        //    await responseMessage.ValidateResponseAsync(cancellationToken);
        //}

        public static async Task<HttpResponseMessage> DownloadAsync(this HttpClient httpClient, string requestUri, IRequest requestModel, CancellationToken cancellationToken)
        {
            httpClient.AddAuthorization(requestModel.ApiKey);

            using var content = JsonContent.Create(requestModel, requestModel.GetType(), null, _defaultSerializerOptions);

            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            requestMessage.Content = content;

            // 无法指定返回的格式
            //requestMessage.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("audio/wav"));

            var responseMessage = await httpClient.SendAsync(requestMessage, cancellationToken);

            await responseMessage.ValidateResponseAsync(cancellationToken);

            return responseMessage;
        }

        public static async Task<T> UploadAsAsync<T>(this HttpClient httpClient, string requestUri, IUploadRequest requestModel, CancellationToken cancellationToken)
        {
            httpClient.AddAuthorization(requestModel.ApiKey);

            using var multipartContent = new MultipartFormDataContent();
            using var fileStream = File.OpenRead(requestModel.File);
            using var streamContent = new StreamContent(fileStream);

            using var fileContent = new StreamContent(fileStream);
            var mimeType = MimeUtility.GetMimeMapping(requestModel.File);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(mimeType);

            multipartContent.Add(fileContent, "file", Path.GetFileName(requestModel.File));

            multipartContent.AddObjectFields(requestModel);

            using var responseMessage = await httpClient.PostAsync(requestUri, multipartContent, cancellationToken);

            await responseMessage.ValidateResponseAsync(cancellationToken);

            return await responseMessage.Content.ReadFromJsonAsync<T>(_defaultSerializerOptions, cancellationToken);
        }

        private static bool IsJsonContentType(HttpResponseMessage response)
        {
            return response.Content.Headers.ContentType?.MediaType?.Equals(JsonContentType, StringComparison.OrdinalIgnoreCase) ?? false;
        }

        private static void AddObjectFields(this MultipartFormDataContent multipartContent, object obj)
        {
            // 将对象序列化为 JSON 流
            var json = JsonSerializer.Serialize(obj, obj.GetType(), _defaultSerializerOptions);

            // 解析 JSON 流为 JsonDocument
            using var doc = JsonDocument.Parse(json);

            // 迭代 JSON 对象的字段并添加到 MultipartFormDataContent
            foreach (var property in doc.RootElement.EnumerateObject())
            {
                string fieldName = property.Name;
                string fieldValue = property.Value.GetRawText();

                // 创建 StringContent 并添加到 MultipartFormDataContent
                var content = new StringContent(fieldValue);
                multipartContent.Add(content, fieldName);
            }
        }

        private class Error
        {
            [JsonPropertyName("code")]
            public string Code { get; set; }

            [JsonPropertyName("message")]
            public string Message { get; set; }

            [JsonPropertyName("status")]
            public int Status { get; set; }
        }
    }
}
