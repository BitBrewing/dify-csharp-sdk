using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI.Interfaces
{
    public interface IMessagesServices
    {
        /// <summary>
        /// 消息反馈（点赞）
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task FeedbacksAsync(FeedbacksRequest request, CancellationToken cancellationToken = default);
    }
}
