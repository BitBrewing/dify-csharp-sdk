using System;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
	public class AudioToTextResponse : ResponseBase
    {
        /// <summary>
        /// 输出文字
        /// </summary>
        [JsonPropertyName("text")]
		public string Text { get; set; }
	}
}

