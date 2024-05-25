using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class ParameterOptions
    {
        /// <summary>
        /// 是否开启
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
    }
}