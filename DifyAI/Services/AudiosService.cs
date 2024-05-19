using System;
using System.Threading;
using System.Threading.Tasks;
using DifyAI.Interfaces;
using DifyAI.ObjectModels;

namespace DifyAI.Services
{
	partial class DifyAIService: IAudiosService
    {
        public async Task TextToAudioAsync(TextToAudioRequest request, CancellationToken cancellationToken = default)
        {
            using var responseMessage = await _httpClient.DownloadAsync("text-to-audio", request, cancellationToken);
            var bytes = await responseMessage.Content.ReadAsByteArrayAsync(cancellationToken);

            await System.IO.File.WriteAllBytesAsync("/Users/liuning/Downloads/test.mp3", bytes, cancellationToken);
        }

        public async Task<AudioToTextResponse> AudioToTextAsync(AudioToTextRequest request, CancellationToken cancellationToken = default)
        {
            return await _httpClient.UploadAsAsync<AudioToTextResponse>("audio-to-text", request, cancellationToken);
        }
    }
}

