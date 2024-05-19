using System;
using DifyAI.ObjectModels;
using System.Threading;
using System.Threading.Tasks;
namespace DifyAI.Interfaces
{
    public interface IAudiosService
	{
        /// <summary>
        /// 语音转文字
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<AudioToTextResponse> AudioToTextAsync(AudioToTextRequest request, CancellationToken cancellationToken = default);
    }
}

