using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DifyAI.ObjectModels;
namespace DifyAI.Interfaces
{
	public interface ICompletionMessagesService
	{
		/// <summary>
		/// 发送消息（阻塞模式）
		/// </summary>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<ChatCompletionResponse> CompletionAsync(ChatCompletionRequest request, CancellationToken cancellationToken = default);

		/// <summary>
		/// 发送消息（流式模式）
		/// </summary>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
        IAsyncEnumerable<ChunkCompletionResponse> StartCompletionAsync(ChatCompletionRequest request, CancellationToken cancellationToken = default);

		/// <summary>
		/// 停止响应
		/// </summary>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
        Task StopCompletionAsync(StopCompletionRequest request, CancellationToken cancellationToken = default);
	}
}

