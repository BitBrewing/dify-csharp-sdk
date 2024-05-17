using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DifyAI.Converters;

namespace DifyAI.ObjectModels
{
    public class CompletionData
    {
        /// <summary>
        ///  执行 ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 关联 Workflow ID
        /// </summary>
        [JsonPropertyName("workflow_id")]
        public string WorkflowId { get; set; }

        /// <summary>
        /// 执行状态 running / succeeded / failed / stopped
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Optional 输出内容
        /// </summary>
        [JsonPropertyName("outputs")]
        public JsonDocument Outputs { get; set; }

        /// <summary>
        /// Optional 错误原因
        /// </summary>
        [JsonPropertyName("error")]
        public string Error { get; set; }

        /// <summary>
        /// Optional 耗时(s)
        /// </summary>
        [JsonPropertyName("elapsed_time")]
        public float? ElapsedTime { get; set; }

        /// <summary>
        /// Optional 总使用 tokens
        /// </summary>
        [JsonPropertyName("total_tokens")]
        public int? TotalTokens { get; set; }

        /// <summary>
        /// 总步数（冗余），默认 0
        /// </summary>
        [JsonPropertyName("total_steps")]
        public int TotalSteps { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [JsonPropertyName("finished_at")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset FinishedAt { get; set; }
    }
}