using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class CompletionMetadata
    {
        /// <summary>
        /// 引用和归属分段列表
        /// </summary>
        [JsonPropertyName("retriever_resources")]
        public IReadOnlyList<CompletionRetrieverResource> RetrieverResources { get; set; }

        /// <summary>
        /// 模型用量信息
        /// </summary>
        [JsonPropertyName("usage")]
        public CompletionUsage Usage { get; set; }
    }
}
