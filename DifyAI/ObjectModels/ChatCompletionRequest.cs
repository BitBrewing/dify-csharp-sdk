using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class ChatCompletionRequest : RequestBase
    {
        /// <summary>
        /// 用户输入/提问内容。
        /// </summary>
        [JsonPropertyName("query")]
        public string Query { get; set; }

        /// <summary>
        /// 允许传入 App 定义的各变量值。 inputs 参数包含了多组键值对（Key/Value pairs），每组的键对应一个特定变量，每组的值则是该变量的具体值。 默认 {}
        /// </summary>
        [JsonPropertyName("inputs")]
        public Dictionary<string, string> Inputs { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// <list type="bullet">
        /// <item>streaming 流式模式（推荐）。基于 SSE（Server-Sent Events）实现类似打字机输出方式的流式返回。</item>
        /// <item>blocking 阻塞模式，等待执行完毕后返回结果。（请求若流程较长可能会被中断）。 由于 Cloudflare 限制，请求会在 100 秒超时无返回后中断。</item>
        /// </list>
        /// </summary>
        [JsonPropertyName("response_mode")]
        public string ResponseMode { get; internal set; }

        /// <summary>
        /// 用户标识，用于定义终端用户的身份，方便检索、统计。 由开发者定义规则，需保证用户标识在应用内唯一。
        /// </summary>
        [JsonPropertyName("user")]
        public string User { get; set; }

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
