using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class ConversationListRequest: RequestBase
    {
        /// <summary>
        /// 用户标识，用于定义终端用户的身份，方便检索、统计。 由开发者定义规则，需保证用户标识在应用内唯一。
        /// </summary>
        [JsonPropertyName("user")]
        public string User { get; set; }

        /// <summary>
        /// 当前页最后面一条记录的 ID，默认 null
        /// </summary>
        [JsonPropertyName("last_id")]
        public string LastId { get; set; }

        /// <summary>
        /// 一次请求返回多少条聊天记录，默认 20 条。
        /// </summary>
        [JsonPropertyName("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// 只返回置顶 true，只返回非置顶 false
        /// </summary>
        [JsonPropertyName("pinned")]
        public bool? Pinned { get; set; }
    }
}
