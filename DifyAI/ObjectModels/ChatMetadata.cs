using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class ChatMetadata
    {
        /// <summary>
        /// 引用和归属分段列表
        /// </summary>
        [JsonPropertyName("retriever_resources")]
        public IReadOnlyList<ChatRetrieverResource> RetrieverResources { get; set; }

        /// <summary>
        /// 模型用量信息
        /// </summary>
        [JsonPropertyName("usage")]
        public ChatUsage Usage { get; set; }
    }
}
