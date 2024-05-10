﻿using DifyAI.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    [JsonConverter(typeof(ChatCompletionStreamResponseConverter))]
    public abstract class CreateCompletionStreamResponse
    {
        /// <summary>
        /// LLM 返回文本块事件，即：完整的文本以分块的方式输出。
        /// </summary>
        public const string Event_Message = "message";

        /// <summary>
        /// 消息结束事件，收到此事件则代表流式返回结束。
        /// </summary>
        public const string Event_MessageEnd = "message_end";

        /// <summary>
        /// 流式输出过程中出现的异常会以 stream event 形式输出，收到异常事件后即结束。
        /// </summary>
        public const string Event_Error = "error";

        /// <summary>
        /// workflow 开始执行
        /// </summary>
        public const string Event_WorkflowStarted = "workflow_started";

        /// <summary>
        /// workflow 执行结束，成功失败同一事件中不同状态
        /// </summary>
        public const string Event_WorkflowFinished = "workflow_finished";

        /// <summary>
        /// node 开始执行
        /// </summary>
        public const string Event_NodeStarted = "node_started";

        /// <summary>
        /// node 执行结束，成功失败同一事件中不同状态
        /// </summary>
        public const string Event_NodeFinished = "node_finished";

        /// <summary>
        /// 事件名称
        /// </summary>
        [JsonPropertyName("event")]
        public string Event { get; set; }
    }
}
