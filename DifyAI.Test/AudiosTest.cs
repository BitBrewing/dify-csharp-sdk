using System;
using DifyAI.ObjectModels;

namespace DifyAI.Test
{
	public class AudiosTest: TestBase
	{
		[Fact]
		public async Task AudioToText()
		{
			var req = new AudioToTextRequest
			{
				File = "/Users/liuning/Downloads/15194.mp3",
				User = "user123"
			};
			var rsp = await _difyAIService.Audios.AudioToTextAsync(req);
			Assert.NotEmpty(rsp.Text);
        }

		[Fact]
		public async Task TextToAudio()
		{
			var req = new TextToAudioRequest
			{
				Text = "用户标识，由开发者定义规则，需保证用户标识在应用内唯一。",
				User = "user123",
			};
            await _difyAIService.Audios.TextToAudioAsync(req);
        }
    }
}

