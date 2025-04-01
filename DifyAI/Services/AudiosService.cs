using System;
using System.Threading;
using System.Threading.Tasks;
using DifyAI.Interfaces;
using DifyAI.ObjectModels;

namespace DifyAI.Services
{
	partial class DifyAIService: IAudiosService
    {
        public async Task<TextToAudioResponse> TextToAudioAsync(TextToAudioRequest request, CancellationToken cancellationToken = default)
        {
            request.Streaming = false;

            using var responseMessage = await _httpClient.DownloadAsync("text-to-audio", request, cancellationToken);
            var bytes = await responseMessage.Content.ReadAsByteArrayAsync(
#if !NETSTANDARD2_0
                cancellationToken
#endif
                );
            
            return new TextToAudioResponse
            {
                AudioBytes = bytes,
                MediaType = responseMessage.Content.Headers.ContentType?.MediaType,
            };
        }

        // 当 Streaming 为true，时，服务端会报错(500)
        //public async Task TextToAudioStreamAsync(TextToAudioRequest request, CancellationToken cancellationToken = default)
        //{
        //    //request.Streaming = true;

        //    await _httpClient.DownloadChunkAsync("text-to-audio", request, cancellationToken);
        //}

        public async Task<AudioToTextResponse> AudioToTextAsync(AudioToTextRequest request, CancellationToken cancellationToken = default)
        {
            return await _httpClient.UploadAsAsync<AudioToTextResponse>("audio-to-text", request, cancellationToken);
        }
    }
}

