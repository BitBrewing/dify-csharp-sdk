using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{

    public class Message
    {
        /// <summary>
        /// 消息 ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}