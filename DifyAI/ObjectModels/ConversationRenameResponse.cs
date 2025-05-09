using DifyAI.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class ConversationRenameResponse : ResponseBase
    {
        /// <summary>
        /// 会话 ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 会话名称
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 用户输入参数。
        /// </summary>
        [JsonPropertyName("inputs")]
        public JsonDocument Inputs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// 开场白
        /// </summary>
        [JsonPropertyName("introduction")]
        public string Introduction { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
