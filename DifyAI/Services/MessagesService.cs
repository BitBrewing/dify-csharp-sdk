using DifyAI.Interfaces;
using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI.Services
{
    partial class DifyAIService : IMessagesService
    {
        public async Task FeedbackAsync(MessageFeedbackRequest request, CancellationToken cancellationToken = default)
        {
            await _httpClient.PostAsync($"messages/{Uri.EscapeDataString(request.MessageId)}/feedbacks", request, cancellationToken);
        }

        public async Task<MessageSuggestedResponse> SuggestedAsync(MessageSuggestedRequest request, CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetAsAsync<MessageSuggestedResponse>($"messages/{Uri.EscapeDataString(request.MessageId)}/suggested", request, cancellationToken);
        }

        public async Task<MessageHistoryResponse> HistoryAsync(MessageHistoryRequest request, CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetAsAsync<MessageHistoryResponse>($"messages", request, cancellationToken);
        }
    }
}
