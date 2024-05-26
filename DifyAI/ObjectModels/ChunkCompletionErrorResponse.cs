using System;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    /// <summary>
    /// 流式输出过程中出现的异常会以 stream event 形式输出，收到异常事件后即结束。
    /// </summary>
	public class ChunkCompletionErrorResponse : ChunkCompletionResponse
    {
        /// <summary>
        /// 任务 ID，用于请求跟踪和下方的停止响应接口
        /// </summary>
        [JsonPropertyName("task_id")]
        public string TaskId { get; set; }

        /// <summary>
        /// 消息唯一 ID
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageId { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }
    }
}

