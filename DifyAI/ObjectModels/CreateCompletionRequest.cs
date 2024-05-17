using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class CreateCompletionRequest: CompletionRequest
    {
        /// <summary>
        /// 用户输入/提问内容。
        /// </summary>
        [Required]
        [JsonPropertyName("query")]
        public string Query { get; set; }

        /// <summary>
        /// （选填）会话 ID，需要基于之前的聊天记录继续对话，必须传之前消息的 conversation_id。
        /// </summary>
        [JsonPropertyName("conversation_id")]
        public string ConversationId { get; set; }

        /// <summary>
        /// （选填）自动生成标题，默认 true。 若设置为 false，则可通过调用会话重命名接口并设置 auto_generate 为 true 实现异步生成标题。
        /// </summary>
        [JsonPropertyName("auto_generate_name")]
        public bool? AutoGenerateName { get; set; }
    }
}
