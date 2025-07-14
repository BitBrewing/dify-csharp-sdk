﻿using DifyAI.Interfaces;
using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI.Services
{
    partial class DifyAIService : IWorkflowsService
    {
        public async Task<CompletionResponse> WorkflowAsync(CompletionRequest request, CancellationToken cancellationToken = default)
        {
            request.ResponseMode = "blocking";

            return await _httpClient.PostAsAsync<CompletionResponse>("workflows/run", request, cancellationToken);
        }

        public async IAsyncEnumerable<ChunkCompletionResponse> WorkflowStreamAsync(CompletionRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            request.ResponseMode = "streaming";

            await foreach (var chunk in _httpClient.PostChunkAsAsync<ChunkCompletionResponse>("workflows/run", request, cancellationToken))
            {
                yield return chunk;
            }
        }

        public async Task StopWorkflowAsync(StopCompletionRequest request, CancellationToken cancellationToken = default)
        {
            await _httpClient.PostAsync($"workflows/tasks/{Uri.EscapeDataString(request.TaskId)}/stop", request, cancellationToken);
        }

        public async Task<WorkflowRunDetailResponse> GetRunDetailsAsync(WorkflowRunDetailRequest request, CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetAsAsync<WorkflowRunDetailResponse>($"workflows/run/{Uri.EscapeDataString(request.WorkflowId)}", request, cancellationToken);
        }
    }
}
