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
    partial class DifyAIService : IConversationsService
    {
        public async Task<ConversationListResponse> ListAsync(ConversationListRequest request, CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetAsAsync<ConversationListResponse>("conversations", request, cancellationToken);
        }

        public async Task DeleteAsync(ConversationDeleteRequest request, CancellationToken cancellationToken = default)
        {
            await _httpClient.DeleteAsync($"conversations/{Uri.EscapeDataString(request.ConversationId)}", request, cancellationToken);
        }

        public async Task<ConversationRenameResponse> RenameAsync(ConversationRenameRequest request, CancellationToken cancellationToken = default)
        {
            return await _httpClient.PostAsAsync<ConversationRenameResponse>($"conversations/{Uri.EscapeDataString(request.ConversationId)}/name", request, cancellationToken);
        }

        public async Task<ConversationVariableListResponse> ListVariablesAsync(ConversationVariableListRequest request, CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetAsAsync<ConversationVariableListResponse>($"conversations/{Uri.EscapeDataString(request.ConversationId)}/variables?user={Uri.EscapeDataString(request.User)}", request, cancellationToken);
        }

        public async Task<ConversationVariableUpdateResponse> UpdateVariableAsync(ConversationVariableUpdateRequest request, CancellationToken cancellationToken = default)
        {
            return await _httpClient.PutAsync<ConversationVariableUpdateResponse>($"conversations/{Uri.EscapeDataString(request.ConversationId)}/variables/{Uri.EscapeDataString(request.VariableId)}", request, cancellationToken);
        }
    }
}
