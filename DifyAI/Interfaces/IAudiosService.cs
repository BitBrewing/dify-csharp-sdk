using System;
using DifyAI.ObjectModels;
using System.Threading;
using System.Threading.Tasks;
namespace DifyAI.Interfaces
{
    public interface IAudiosService
	{
        /// <summary>
        /// 文字转语音
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TextToAudioResponse> TextToAudioAsync(TextToAudioRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 语音转文字
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<AudioToTextResponse> AudioToTextAsync(AudioToTextRequest request, CancellationToken cancellationToken = default);
        //Task TextToAudioStreamAsync(TextToAudioRequest request, CancellationToken cancellationToken = default);
    }
}

