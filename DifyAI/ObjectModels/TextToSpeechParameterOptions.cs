using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class TextToSpeechParameterOptions : ParameterOptions
    {
        /// <summary>
        /// 音色
        /// </summary>
        [JsonPropertyName("voice")]
        public string Voice { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }
    }
}