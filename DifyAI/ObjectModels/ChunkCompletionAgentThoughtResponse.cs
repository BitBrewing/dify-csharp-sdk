using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using DifyAI.Converters;

namespace DifyAI.ObjectModels
{
	/// <summary>
	/// Agent模式下有关Agent思考步骤的相关内容，涉及到工具调用（仅Agent模式下使用）
	/// </summary>
	public class ChunkCompletionAgentThoughtResponse : ChunkCompletionResponse
	{
		/// <summary>
		/// agent_thought ID，每一轮Agent迭代都会有一个唯一的id
		/// </summary>
		[JsonPropertyName("id")]
		public string Id { get; set; }

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
		/// agent_thought在消息中的位置，如第一轮迭代position为1
		/// </summary>
		[JsonPropertyName("position")]
		public int? Position { get; set; }

		/// <summary>
		/// agent的思考内容
		/// </summary>
		[JsonPropertyName("thought")]
		public string Thought { get; set; }

		/// <summary>
		/// 工具调用的返回结果
		/// </summary>
		[JsonPropertyName("observation")]
		public string Observation { get; set; }

		/// <summary>
		/// 使用的工具列表，以 ; 分割多个工具
		/// </summary>
		[JsonPropertyName("tool")]
		public string Tool { get; set; }

		/// <summary>
		/// 工具的输入，JSON格式的字符串(object)。如：{"dalle3": {"prompt": "a cute cat"}}
		/// </summary>
		[JsonPropertyName("tool_input")]
		public string ToolInput { get; set; }

		/// <summary>
        /// 消息创建时间戳，如：1705395332
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset CreatedAt { get; set; }

		/// <summary>
		/// 当前 agent_thought 关联的文件ID
		/// </summary>
		[JsonPropertyName("message_files")]
		public IReadOnlyList<string> MessageFiles { get; set; }

		/// <summary>
        /// 会话 ID
        /// </summary>
        [JsonPropertyName("conversation_id")]
        public string ConversationId { get; set; }
	}
}

