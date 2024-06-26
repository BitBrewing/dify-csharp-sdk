﻿using DifyAI.Interfaces;
using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI.Services
{
    partial class DifyAIService : IChatMessagesService
    {
        public async Task<ChatCompletionResponse> ChatAsync(ChatCompletionRequest request, CancellationToken cancellationToken = default)
        {
            request.ResponseMode = "blocking";

            return await _httpClient.PostAsAsync<ChatCompletionResponse>("chat-messages", request, cancellationToken);
        }

        public async IAsyncEnumerable<ChunkCompletionResponse> ChatStreamAsync(ChatCompletionRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            request.ResponseMode = "streaming";

            await foreach (var chunk in _httpClient.PostChunkAsAsync<ChunkCompletionResponse>("chat-messages", request, cancellationToken))
            {
                yield return chunk;
            }
        }

        public async Task StopChatAsync(StopCompletionRequest request, CancellationToken cancellationToken = default)
        {
            await _httpClient.PostAsync($"chat-messages/{Uri.EscapeDataString(request.TaskId)}/stop", request, cancellationToken);
        }
    }
}
