using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI.Interfaces
{
    public interface IChatMessagesService
    {
        /// <summary>
        /// 发送对话消息（阻塞模式）
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ChatCompletionResponse> ChatAsync(ChatCompletionRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 发送对话消息（流式模式）
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        IAsyncEnumerable<ChunkCompletionResponse> ChatStreamAsync(ChatCompletionRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 停止响应
        /// </summary>
        /// <remarks>仅支持流式模式</remarks>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        Task StopChatAsync(StopCompletionRequest request, CancellationToken cancellationToken = default);
    }
}
