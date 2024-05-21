using DifyAI.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class Conversation
    {
        /// <summary>
        /// 会话 ID。
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 会话名称，默认为会话中用户最开始问题的截取。
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 用户输入参数列表。
        /// </summary>
        [JsonPropertyName("inputs")]
        public JsonDocument Inputs { get; set; }

        /// <summary>
        /// 开场白。
        /// </summary>
        [JsonPropertyName("introduction")]
        public string Introduction { get; set; }

        /// <summary>
        /// 创建时间。
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
