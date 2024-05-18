using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [JsonIgnore]
        public string MessageId { get; set; }
    }
}
