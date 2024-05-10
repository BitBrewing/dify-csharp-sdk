using DifyAI.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class CreateCompletionResponse
    {
        /// <summary>
        /// message: LLM 返回文本块事件，即：完整的文本以分块的方式输出。
        /// </summary>
        [JsonPropertyName("event")]
        public string Event { get; set; }

        /// <summary>
        /// 任务 ID，用于请求跟踪和下方的停止响应接口
        /// </summary>
        [JsonPropertyName("task_id")]
        public string TaskId { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 消息唯一 ID
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageId { get; set; }

        /// <summary>
        /// 会话 ID
        /// </summary>
        [JsonPropertyName("conversation_id")]
        public string ConversationId { get; set; }

        /// <summary>
        /// App 模式
        /// </summary>
        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        /// <summary>
        /// 完整回复内容
        /// </summary>
        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        /// <summary>
        /// 元数据
        /// </summary>
        [JsonPropertyName("metadata")]
        public ChatMetadata Metadata { get; set; }

        /// <summary>
        /// 消息创建时间戳，如：1705395332
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
