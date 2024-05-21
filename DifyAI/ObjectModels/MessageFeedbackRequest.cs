using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class MessageFeedbackRequest : RequestBase
    {
        /// <summary>
        /// 消息 ID
        /// </summary>
        [JsonIgnore]
        public string MessageId { get; set; }

        /// <summary>
        /// 用户标识，用于定义终端用户的身份，方便检索、统计。 由开发者定义规则，需保证用户标识在应用内唯一。
        /// </summary>
        [JsonPropertyName("user")]
        public string User { get; set; }

        /// <summary>
        /// 点赞 like, 点踩 dislike, 撤销点赞 null
        /// </summary>
        [JsonPropertyName("rating")]
        public string Rating { get; set; }
    }
}
