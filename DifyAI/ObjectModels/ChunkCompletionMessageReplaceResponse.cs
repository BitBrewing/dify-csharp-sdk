using System;
using System.Text.Json.Serialization;
using DifyAI.Converters;
namespace DifyAI.ObjectModels
{
	public class ChunkCompletionMessageReplaceResponse: ChunkCompletionResponse
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

        /// <summary>
        /// 会话 ID
        /// </summary>
        [JsonPropertyName("conversation_id")]
        public string ConversationId { get; set; }

		/// <summary>
        /// 完整回复内容
        /// </summary>
        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        /// <summary>
        /// 消息创建时间戳，如：1705395332
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset CreatedAt { get; set; }
	}
}

