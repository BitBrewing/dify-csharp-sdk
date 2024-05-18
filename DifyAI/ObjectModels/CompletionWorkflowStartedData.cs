using DifyAI.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class CompletionWorkflowStartedData
    {
        /// <summary>
        /// workflow 执行 ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 关联 Workflow ID
        /// </summary>
        [JsonPropertyName("workflow_id")]
        public string WorkflowId { get; set; }

        /// <summary>
        /// 自增序号，App 内自增，从 1 开始
        /// </summary>
        [JsonPropertyName("sequence_number")]
        public int SequenceNumber { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
