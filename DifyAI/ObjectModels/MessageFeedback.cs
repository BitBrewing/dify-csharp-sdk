using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class MessageFeedback
    {
        /// <summary>
        /// 点赞 like / 点踩 dislike。
        /// </summary>
        [JsonPropertyName("rating")]
        public string Rating { get; set; }
    }
}
