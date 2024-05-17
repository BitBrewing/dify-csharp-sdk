using DifyAI.Interfaces;
using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI.Internals
{
    partial class DifyAIService : IChatMessagesService
    {
        public async Task<CreateCompletionResponse> CreateCompletionAsync(CreateCompletionRequest request, CancellationToken cancellationToken = default)
        {
            request.ResponseMode = "blocking";

            return await _httpClient.PostAsAsync<CreateCompletionResponse>("chat-messages", request, cancellationToken);
        }

        public async IAsyncEnumerable<CreateCompletionStreamResponse> CreateCompletionStreamAsync(CreateCompletionRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            request.ResponseMode = "streaming";

            await foreach (var chunk in _httpClient.PostChunkAsAsync<CreateCompletionStreamResponse>("chat-messages", request, cancellationToken))
            {
                yield return chunk;
            }
        }

        public async Task StopCompletionStreamAsync(StopCompletionRequest request, CancellationToken cancellationToken = default)
        {
            await _httpClient.PostAsync($"chat-messages/{Uri.EscapeDataString(request.TaskId)}/stop", request, cancellationToken);
        }
    }
}
