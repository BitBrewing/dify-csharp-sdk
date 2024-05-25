using System.Text.Json;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class SensitiveWordAvoidanceParameterOptions : ParameterOptions
    {
        /// <summary>
        /// 类别
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// 配置
        /// </summary>
        [JsonPropertyName("config")]
        public JsonDocument Config { get; set; }
    }
}
