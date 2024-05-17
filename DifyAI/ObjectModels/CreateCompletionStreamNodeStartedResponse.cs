using System;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    /// <summary>
    /// node 开始执行
    /// </summary>
    public class CreateCompletionStreamNodeStartedResponse : CreateCompletionStreamResponse
    {
        /// <summary>
        /// 任务 ID，用于请求跟踪和下方的停止响应接口
        /// </summary>
        [JsonPropertyName("task_id")]
        public string TaskId { get; set; }

        /// <summary>
        /// workflow 执行 ID
        /// </summary>
        [JsonPropertyName("workflow_run_id")]
        public string WorkflowRunId { get; set; }

        /// <summary>
        /// 详细内容
        /// </summary>
        [JsonPropertyName("data")]
        public NodeStartedData Data { get; set; }
    }
}

