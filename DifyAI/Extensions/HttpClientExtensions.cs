using DifyAI.ObjectModels;
using MimeMapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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

        public static void AddAuthorization(this HttpClient httpClient, string apiKey, string baseDomain)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"Bearer {apiKey}");
            }
            if (!string.IsNullOrEmpty(baseDomain))
            {
                var host = new UriBuilder(baseDomain);
                if (!host.Path.EndsWith("/"))
                {
                    host.Path += "/";
                }
                httpClient.BaseAddress = host.Uri;
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
            httpClient.AddAuthorization(requestModel.ApiKey, requestModel.BaseDomain);

            using var responseMessage = await httpClient.GetAsync(AddQueryString(requestUri, requestModel), cancellationToken);

            await responseMessage.ValidateResponseAsync(cancellationToken);

            return await responseMessage.Content.ReadFromJsonAsync<T>(_defaultSerializerOptions, cancellationToken);
        }

        private static async Task<HttpResponseMessage> PostCoreAsync(this HttpClient httpClient, string requestUri, IRequest requestModel, CancellationToken cancellationToken)
        {
            httpClient.AddAuthorization(requestModel.ApiKey, requestModel.BaseDomain);

            using var content = JsonContent.Create(requestModel, requestModel.GetType(), null, _defaultSerializerOptions);
            var responseMessage = await httpClient.PostAsync(requestUri, content, cancellationToken);

            await responseMessage.ValidateResponseAsync(cancellationToken);

            return responseMessage;
        }

        public static async Task DeleteAsync(this HttpClient httpClient, string requestUri, IRequest requestModel, CancellationToken cancellationToken)
        {
            httpClient.AddAuthorization(requestModel.ApiKey, requestModel.BaseDomain);

            using var content = JsonContent.Create(requestModel, requestModel.GetType(), null, _defaultSerializerOptions);
            using var requestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri);
            requestMessage.Content = content;

            using var responseMessage = await httpClient.SendAsync(requestMessage, cancellationToken);

            await responseMessage.ValidateResponseAsync(cancellationToken);
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
            httpClient.AddAuthorization(requestModel.ApiKey, requestModel.BaseDomain);

            using var content = JsonContent.Create(requestModel, requestModel.GetType(), null, _defaultSerializerOptions);
            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);

            requestMessage.Content = content;
            using var responseMessage = await httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

            await responseMessage.ValidateResponseAsync(cancellationToken);

#if !NETSTANDARD2_0
            await
#endif 
                using var stream = await responseMessage.Content.ReadAsStreamAsync(
#if !NETSTANDARD2_0
                cancellationToken
#endif
            );

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
                if (line == "event: ping")
                    continue;

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
            httpClient.AddAuthorization(requestModel.ApiKey, requestModel.BaseDomain);

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
            httpClient.AddAuthorization(requestModel.ApiKey, requestModel.BaseDomain);

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

        public static async Task<T> UploadDocumentAsync<T>(this HttpClient httpClient, string requestUri, IUploadRequest requestModel, CancellationToken cancellationToken)
        {
            httpClient.AddAuthorization(requestModel.ApiKey, requestModel.BaseDomain);

            using var multipartContent = new MultipartFormDataContent();
            using var fileStream = File.OpenRead(requestModel.File);
            using var streamContent = new StreamContent(fileStream);

            multipartContent.AddObjectAsJsonData(requestModel);

            using var fileContent = new StreamContent(fileStream);
            var mimeType = MimeUtility.GetMimeMapping(requestModel.File);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(mimeType);

            multipartContent.Add(fileContent, "file", Path.GetFileName(requestModel.File));

            using var responseMessage = await httpClient.PostAsync(requestUri, multipartContent, cancellationToken);

            await responseMessage.ValidateResponseAsync(cancellationToken);

            return await responseMessage.Content.ReadFromJsonAsync<T>(_defaultSerializerOptions, cancellationToken);
        }

        private static bool IsJsonContentType(HttpResponseMessage response)
        {
            return response.Content.Headers.ContentType?.MediaType?.Equals(JsonContentType, StringComparison.OrdinalIgnoreCase) ?? false;
        }

        private static IEnumerable<KeyValuePair<string, string>> GetObjectFields(object obj)
        {
            // 将对象序列化为 JSON
            var json = JsonSerializer.Serialize(obj, obj.GetType(), _defaultSerializerOptions);

            // 解析 JSON 为 JsonDocument
            using var doc = JsonDocument.Parse(json);

            return doc.RootElement.EnumerateObject().ToDictionary(x => x.Name, x => x.Value.ValueKind == JsonValueKind.String ? x.Value.ToString() : x.Value.GetRawText());
        }

        private static string AddQueryString(string url, object obj)
        {
            var queryString = new StringBuilder();
            foreach (var fields in GetObjectFields(obj))
            {
                queryString.Append($"&{fields.Key}={Uri.EscapeDataString(fields.Value)}");
            }

            if (queryString.Length > 0)
            {
                if (url.Contains('?'))
                {
                    url += queryString;
                }
                else
                {
                    url += "?" + queryString.Remove(0, 1);
                }
            }

            return url;
        }

        private static void AddObjectFields(this MultipartFormDataContent multipartContent, object obj)
        {
            // 迭代 对象的字段并添加到 MultipartFormDataContent
            foreach (var fields in GetObjectFields(obj))
            {
                // 创建 StringContent 并添加到 MultipartFormDataContent
                var content = new StringContent(fields.Value);
                multipartContent.Add(content, fields.Key);
            }
        }

        private static void AddObjectAsJsonData(this MultipartFormDataContent multipartContent, object obj)
        {
            var json = JsonSerializer.Serialize(obj, _defaultSerializerOptions);
            multipartContent.Add(new StringContent(json), "data");
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
