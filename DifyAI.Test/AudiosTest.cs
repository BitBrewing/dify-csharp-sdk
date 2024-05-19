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
    }
}

