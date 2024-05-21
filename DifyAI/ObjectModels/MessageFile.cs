using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class MessageFile
    {
        /// <summary>
        /// 文件 ID。
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 文件类型，image 图片。
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// 预览图片地址。
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// 文件归属方，user 或 assistant。
        /// </summary>
        [JsonPropertyName("belongs_to")]
        public string BelongsTo { get; set; }
    }
}
