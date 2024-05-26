using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using DifyAI.Json;
using System.Text.Json;

namespace DifyAI.ObjectModels
{

    public class Message
    {
        /// <summary>
        /// 消息 ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 会话 ID。
        /// </summary>
        [JsonPropertyName("conversation_id")]
        public string ConversationId { get; set; }

        /// <summary>
        /// 用户输入参数列表。
        /// </summary>
        [JsonPropertyName("inputs")]
        public JsonDocument Inputs { get; set; }

        /// <summary>
        /// 用户输入 / 提问内容。
        /// </summary>
        [JsonPropertyName("query")]
        public string Query { get; set; }

        /// <summary>
        /// 消息文件列表。
        /// </summary>
        [JsonPropertyName("message_files")]
        public IReadOnlyList<MessageFile> MessageFiles { get; set; }

        /// <summary>
        /// 回答消息内容。
        /// </summary>
        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        /// <summary>
        /// 创建时间。
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// 反馈信息。
        /// </summary>
        [JsonPropertyName("feedback")]
        public MessageFeedback Feedback { get; set; }

        /// <summary>
        /// 引用和归属分段列表。
        /// </summary>
        [JsonPropertyName("retriever_resources")]
        public IReadOnlyList<RetrieverResource> RetrieverResources { get; set; }
    }
}