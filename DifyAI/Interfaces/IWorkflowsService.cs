using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DifyAI.ObjectModels;

namespace DifyAI.Interfaces
{
    public interface IWorkflowsService
    {
        /// <summary>
        /// 执行 workflow（阻塞模式）
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CompletionResponse> WorkflowAsync(CompletionRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 执行 workflow（流式模式）
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        IAsyncEnumerable<CompletionResponse> WorkflowStreamAsync(CompletionRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 停止响应
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task StopWorkflowAsync(StopCompletionRequest request, CancellationToken cancellationToken = default);
    }
}
