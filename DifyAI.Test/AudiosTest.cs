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
                ApiKey = "app-BcUpirbWkIyTgQUIrP8zOeuf",
                File = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Assets/Audio.mp3"),
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
				ApiKey = "app-BcUpirbWkIyTgQUIrP8zOeuf",
                Text = "由于模型在训练阶段的差异，不同模型对于角色名的指令遵循程度不同，如 Human/Assistant，Human/AI，人类/助手等等。为适配多模型的提示响应效果，系统提供了对话角色名的设置，修改对话角色名将会修改会话历史的角色前缀。",
				User = "user123",
			};
            var rsp = await _difyAIService.Audios.TextToAudioAsync(req);
			Assert.NotEmpty(rsp.AudioBytes);
        }

		//[Fact]
		//public async Task TextToAudioStream()
		//{
  //          var req = new TextToAudioRequest
  //          {
  //              ApiKey = "app-BcUpirbWkIyTgQUIrP8zOeuf",
  //              Text = "由于模型在训练阶段的差异，不同模型对于角色名的指令遵循程度不同，如 Human/Assistant，Human/AI，人类/助手等等。为适配多模型的提示响应效果，系统提供了对话角色名的设置，修改对话角色名将会修改会话历史的角色前缀。",
  //              User = "user123",
  //          };
		//	await _difyAIService.Audios.TextToAudioStreamAsync(req);
  //      }
    }
}

