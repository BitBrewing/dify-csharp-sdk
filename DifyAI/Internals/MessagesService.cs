using DifyAI.Interfaces;
using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI.Internals
{
    partial class DifyAIService : IMessagesService
    {
        public async Task FeedbacksAsync(FeedbacksRequest request, CancellationToken cancellationToken = default)
        {
            await _httpClient.PostAsync($"messages/{Uri.EscapeDataString(request.MessageId)}/feedbacks", request, cancellationToken);
        }

        public async Task<SuggestedResponse> SuggestedAsync(SuggestedRequest request, CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetAsAsync<SuggestedResponse>($"messages/{Uri.EscapeDataString(request.MessageId)}/suggested", request, cancellationToken);
        }
    }
}
