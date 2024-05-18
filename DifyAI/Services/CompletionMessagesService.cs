using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using DifyAI.Interfaces;
using DifyAI.ObjectModels;

namespace DifyAI.Services
{
	partial class DifyAIService: ICompletionMessagesService
    {
		public async Task<ChatCompletionResponse> CompletionAsync(ChatCompletionRequest request, CancellationToken cancellationToken = default)
        {
            request.ResponseMode = "blocking";

            return await _httpClient.PostAsAsync<ChatCompletionResponse>("completion-messages", request, cancellationToken);
        }

        public async IAsyncEnumerable<ChunkCompletionResponse> StartCompletionAsync(ChatCompletionRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            request.ResponseMode = "streaming";

            await foreach (var chunk in _httpClient.PostChunkAsAsync<ChunkCompletionResponse>("completion-messages", request, cancellationToken))
            {
                yield return chunk;
            }
        }

        public async Task StopCompletionAsync(StopCompletionRequest request, CancellationToken cancellationToken = default)
        {
            await _httpClient.PostAsync($"completion-messages/{Uri.EscapeDataString(request.TaskId)}/stop", request, cancellationToken);
        }
	}
}

