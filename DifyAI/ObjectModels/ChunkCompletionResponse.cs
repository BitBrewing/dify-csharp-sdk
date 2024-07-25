using DifyAI.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "event", DefaultType = typeof(ChunkCompletionUnknownResponse))]
    [JsonDerivedType(typeof(ChunkCompletionMessageResponse), Event_Message)]
    [JsonDerivedType(typeof(ChunkCompletionMessageReplaceResponse), Event_MessageReplace)]
    [JsonDerivedType(typeof(ChunkCompletionMessageFileResponse), Event_MessageFile)]
    [JsonDerivedType(typeof(ChunkCompletionMessageEndResponse), Event_MessageEnd)]
    [JsonDerivedType(typeof(ChunkCompletionWorkflowStartedResponse), Event_WorkflowStarted)]
    [JsonDerivedType(typeof(ChunkCompletionWorkflowFinishedResponse), Event_WorkflowFinished)]
    [JsonDerivedType(typeof(ChunkCompletionNodeStartedResponse), Event_NodeStarted)]
    [JsonDerivedType(typeof(ChunkCompletionNodeFinishedResponse), Event_NodeFinished)]
    [JsonDerivedType(typeof(ChunkCompletionAgentMessageResponse), Event_AgentMessage)]
    [JsonDerivedType(typeof(ChunkCompletionAgentThoughtResponse), Event_AgentThought)]
    [JsonDerivedType(typeof(ChunkCompletionErrorResponse), Event_Error)]
    public abstract class ChunkCompletionResponse
    {
        /// <summary>
        /// LLM 返回文本块事件，即：完整的文本以分块的方式输出。
        /// </summary>
        public const string Event_Message = "message";

        /// <summary>
        /// 消息内容替换事件。 开启内容审查和审查输出内容时，若命中了审查条件，则会通过此事件替换消息内容为预设回复。
        /// </summary>
        public const string Event_MessageReplace = "message_replace";

        /// <summary>
        /// 文件事件，表示有新文件需要展示
        /// </summary>
        public const string Event_MessageFile = "message_file";

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
        /// Agent模式下返回文本块事件，即：在Agent模式下，文章的文本以分块的方式输出（仅Agent模式下使用）
        /// </summary>
        public const string Event_AgentMessage = "agent_message";

        /// <summary>
        /// Agent模式下有关Agent思考步骤的相关内容，涉及到工具调用（仅Agent模式下使用）
        /// </summary>
        public const string Event_AgentThought = "agent_thought";

        /// <summary>
        /// 事件名称
        /// </summary>
        [JsonPropertyName("event")]
        public string Event { get; set; }
    }
}
