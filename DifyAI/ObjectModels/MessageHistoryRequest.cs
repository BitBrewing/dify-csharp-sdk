using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class MessageHistoryRequest : RequestBase
    {
        /// <summary>
        /// 会话 ID
        /// </summary>
        [JsonPropertyName("conversation_id")]
        public string ConversationId { get; set; }

        /// <summary>
        /// 用户标识，用于定义终端用户的身份，方便检索、统计。 由开发者定义规则，需保证用户标识在应用内唯一。
        /// </summary>
        [JsonPropertyName("user")]
        public string User { get; set; }

        /// <summary>
        /// 当前页第一条聊天记录的 ID，默认 null
        /// </summary>
        [JsonPropertyName("first_id")]
        public string FirstId { get; set; }

        /// <summary>
        /// 一次请求返回多少条聊天记录，默认 20 条。
        /// </summary>
        [JsonPropertyName("limit")]
        public int? Limit { get; set; }
    }
}

