using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI.Interfaces
{
    public interface IConversationsService
    {
        /// <summary>
        /// 删除会话
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteAsync(ConversationDeleteRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取会话列表
        /// </summary>
        /// <remarks>获取当前用户的会话列表，默认返回最近的 20 条。</remarks>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ConversationListResponse> ListAsync(ConversationListRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 会话重命名
        /// </summary>
        /// <remarks>对会话进行重命名，会话名称用于显示在支持多会话的客户端上。</remarks>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ConversationRenameResponse> RenameAsync(ConversationRenameRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取会话变量列表
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ConversationVariableListResponse> ListVariablesAsync(ConversationVariableListRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 更新会话变量
        /// </summary>
        /// <remarks>通过 conversation_id 和 variable_id 更新指定会话的变量值。</remarks>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ConversationVariableUpdateResponse> UpdateVariableAsync(ConversationVariableUpdateRequest request, CancellationToken cancellationToken = default);
    }
}
