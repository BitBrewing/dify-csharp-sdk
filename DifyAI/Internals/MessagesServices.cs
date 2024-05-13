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
    partial class DifyAIService : IMessagesServices
    {
        public async Task FeedbacksAsync(FeedbacksRequest request, CancellationToken cancellationToken = default)
        {
            await _httpClient.PostAsync($"messages/{Uri.EscapeDataString(request.MessageId)}/feedbacks", request, cancellationToken);
        }
    }
}
