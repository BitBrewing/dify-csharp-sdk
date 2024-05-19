using System;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
	public class AudioToTextResponse
	{
        /// <summary>
        /// 输出文字
        /// </summary>
        [JsonPropertyName("text")]
		public string Text { get; set; }
	}
}

