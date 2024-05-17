using DifyAI.Interfaces;
using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI.Internals
{
    partial class DifyAIService : IWorkflowsService
    {
        public async Task<CompletionResponse> RunAsync(CompletionRequest request, CancellationToken cancellationToken = default)
        {
            request.ResponseMode = "blocking";

            return await _httpClient.PostAsAsync<CompletionResponse>("workflows/run", request, cancellationToken);
        }

        public async IAsyncEnumerable<CompletionResponse> RunStreamAsync(CompletionRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            request.ResponseMode = "streaming";

            await foreach (var chunk in _httpClient.PostChunkAsAsync<CompletionResponse>("workflows/run", request, cancellationToken))
            {
                yield return chunk;
            }
        }

        public async Task StopAsync()
        {

        }
    }
}
