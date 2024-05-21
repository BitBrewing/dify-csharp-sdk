using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI.Interfaces
{
    public interface IMessagesService
    {
        /// <summary>
        /// 消息反馈（点赞）
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task FeedbackAsync(MessageFeedbackRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取会话历史消息
        /// </summary>
        /// <remarks>滚动加载形式返回历史聊天记录，第一页返回最新 limit 条，即：倒序返回。</remarks>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<MessageHistoryResponse> HistoryAsync(MessageHistoryRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取下一轮建议问题列表
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<MessageSuggestedResponse> SuggestedAsync(MessageSuggestedRequest request, CancellationToken cancellationToken = default);
    }
}
