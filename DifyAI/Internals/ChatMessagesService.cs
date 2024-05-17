using DifyAI.Interfaces;
using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI.Internals
{
    partial class DifyAIService : IChatMessagesService
    {
        private static readonly JsonSerializerOptions _defaultSerializerOptions = new()
        {
            WriteIndented = false,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            NumberHandling = JsonNumberHandling.AllowReadingFromString, // 有些数字型的dify返回为字符串
        };

        public async Task<CreateCompletionResponse> CreateCompletionAsync(CreateCompletionRequest request, CancellationToken cancellationToken = default)
        {
            request.ResponseMode = "blocking";

            return await _httpClient.PostAsAsync<CreateCompletionResponse>("chat-messages", request, cancellationToken);
        }

        public async IAsyncEnumerable<CreateCompletionStreamResponse> CreateCompletionStreamAsync(CreateCompletionRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            request.ResponseMode = "streaming";

            await using var stream = await _httpClient.PostAsStreamAsync("chat-messages", request, cancellationToken);
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

                CreateCompletionStreamResponse block;
                try
                {
                    // When the response is good, each line is a serializable CompletionCreateRequest
                    block = JsonSerializer.Deserialize<CreateCompletionStreamResponse>(line, _defaultSerializerOptions);
                }
                catch (Exception)
                {
                    // When the API returns an error, it does not come back as a block, it returns a single character of text ("{").
                    // In this instance, read through the rest of the response, which should be a complete object to parse.
                    line += await reader.ReadToEndAsync();
                    block = JsonSerializer.Deserialize<CreateCompletionStreamResponse>(line, _defaultSerializerOptions);
                }

                if (null != block)
                {
                    yield return block;
                }
            }
        }

        public async Task StopCompletionStreamAsync(StopCompletionRequest request, CancellationToken cancellationToken = default)
        {
            await _httpClient.PostAsync($"chat-messages/{Uri.EscapeDataString(request.TaskId)}/stop", request, cancellationToken);
        }
    }
}
