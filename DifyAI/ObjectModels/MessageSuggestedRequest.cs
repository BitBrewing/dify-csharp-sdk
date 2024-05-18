using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class MessageSuggestedRequest : RequestBase
    {
        /// <summary>
        /// 消息 ID
        /// </summary>
        [JsonIgnore]
        public string MessageId { get; set; }
    }
}
