using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    /// <summary>
    /// 文件事件，表示有新文件需要展示
    /// </summary>
    public class CompletionStreamMessageFileResponse: CompletionStreamResponse
    {
        /// <summary>
        /// 文件唯一ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 文件类型，目前仅为image
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// 文件归属，user或assistant，该接口返回仅为 assistant
        /// </summary>
        [JsonPropertyName("belongs_to")]
        public string BelongsTo { get; set; }

        /// <summary>
        /// 文件访问地址
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// 会话ID
        /// </summary>
        [JsonPropertyName("conversation_id")]
        public string ConversationId { get; set; }
    }
}
