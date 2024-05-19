using System;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
	public class TextToAudioRequest
	{
        /// <summary>
        /// 语音生成内容。
        /// </summary>
        [JsonPropertyName("text")]
		public string Text { get; set; }

        /// <summary>
        /// 用户标识，由开发者定义规则，需保证用户标识在应用内唯一。
        /// </summary>
        [JsonPropertyName("user")]
        public string User { get; set; }

        /// <summary>
        /// 是否启用流式输出true、false。
        /// </summary>
        [JsonPropertyName("streaming")]
        public bool Streaming { get; set; }
    }
}

