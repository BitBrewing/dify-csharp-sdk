using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class ConversationDeleteRequest: RequestBase
    {
        /// <summary>
        /// 会话ID
        /// </summary>
        [JsonIgnore]
        public string ConversationId { get; set; }

        /// <summary>
        /// 用户标识，由开发者定义规则，需保证用户标识在应用内唯一。
        /// </summary>
        [JsonPropertyName("user")]
        public string User { get; set; }
    }
}
