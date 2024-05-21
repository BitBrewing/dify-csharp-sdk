using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class ConversationRenameRequest: RequestBase
    {
        /// <summary>
        /// 会话ID
        /// </summary>
        [JsonIgnore]
        public string ConversationId { get; set; }

        /// <summary>
        /// 名称，若 auto_generate 为 true 时，该参数可不传。
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 自动生成标题，默认 false。
        /// </summary>
        [JsonPropertyName("auto_generate")]
        public bool? AutoGenerate { get; set; }

        /// <summary>
        /// 用户标识，由开发者定义规则，需保证用户标识在应用内唯一。
        /// </summary>
        [JsonPropertyName("user")]
        public string User { get; set; }
    }
}
