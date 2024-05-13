using DifyAI.ObjectModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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

        public static async Task PostAsync(this HttpClient httpClient, string requestUri, DifyAIRequestBase requestModel, CancellationToken cancellationToken)
        {
            httpClient.AddAuthorization(requestModel.ApiKey);

            var json = JsonSerializer.Serialize(requestModel, requestModel.GetType(), _defaultSerializerOptions);
            using var conetnt = new StringContent(json, Encoding.UTF8, JsonContentType);
            using var responseMessage = await httpClient.PostAsync(requestUri, conetnt, cancellationToken);

            await responseMessage.ValidateResponseAsync(cancellationToken);
        }

        public static async Task<T> PostAsAsync<T>(this HttpClient httpClient, string requestUri, DifyAIRequestBase requestModel, CancellationToken cancellationToken)
        {
            httpClient.AddAuthorization(requestModel.ApiKey);

            var json = JsonSerializer.Serialize(requestModel, requestModel.GetType(), _defaultSerializerOptions);
            using var conetnt = new StringContent(json, Encoding.UTF8, JsonContentType);
            using var responseMessage = await httpClient.PostAsync(requestUri, conetnt, cancellationToken);
            
            await responseMessage.ValidateResponseAsync(cancellationToken);

            return await responseMessage.Content.ReadFromJsonAsync<T>(_defaultSerializerOptions, cancellationToken);
        }

        public static async Task<Stream> PostAsStreamAsync(this HttpClient httpClient, string requestUri, DifyAIRequestBase requestModel, CancellationToken cancellationToken)
        {
            httpClient.AddAuthorization(requestModel.ApiKey);

            using var content = JsonContent.Create(requestModel, requestModel.GetType(), null, _defaultSerializerOptions);
            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);

            requestMessage.Content = content;
            var responseMessage = await httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

            await responseMessage.ValidateResponseAsync(cancellationToken);

            return await responseMessage.Content.ReadAsStreamAsync(cancellationToken);
        }

        private static bool IsJsonContentType(HttpResponseMessage response)
        {
            return response.Content.Headers.ContentType?.MediaType?.Equals(JsonContentType, StringComparison.OrdinalIgnoreCase) ?? false;
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
