using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    /// <summary>
    /// 获取下一轮建议问题请求
    /// </summary>
    public class MessageSuggestedRequest : RequestBase
    {
        /// <summary>
        /// 消息 ID
        /// </summary>
        [JsonIgnore]
        public string MessageId { get; set; }
        
        /// <summary>
        /// 用户标识，由开发者定义规则，需保证用户标识在应用内唯一。
        /// </summary>
        [JsonPropertyName("user")]
        public string User { get; set; }
    }
}
