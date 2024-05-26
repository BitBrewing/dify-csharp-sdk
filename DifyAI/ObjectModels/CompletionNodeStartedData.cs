using DifyAI.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class CompletionNodeStartedData
    {
        /// <summary>
        /// workflow 执行 ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 节点 ID
        /// </summary>
        [JsonPropertyName("node_id")]
        public string NodeId { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>
        [JsonPropertyName("node_type")]
        public string NodeType { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// 执行序号，用于展示 Tracing Node 顺序
        /// </summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary>
        /// 前置节点 ID，用于画布展示执行路径
        /// </summary>
        [JsonPropertyName("predecessor_node_id")]
        public string PredecessorNodeId { get; set; }

        /// <summary>
        /// 节点中所有使用到的前置节点变量内容
        /// </summary>
        [JsonPropertyName("inputs")]
        public JsonDocument Inputs { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
