using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using DifyAI.ObjectModels;
using DifySdk.Dtos;

namespace DifyAI.Converters
{
    internal class ChunkCompletionResponseConverter : PolymorphicConverterBase<ChunkCompletionResponse>
    {
        private static readonly Dictionary<string, Type> _derivedTypes = new()
        {
            [ChunkCompletionResponse.Event_Message] = typeof(ChunkCompletionMessageResponse),
            [ChunkCompletionResponse.Event_MessageReplace] = typeof(ChunkCompletionMessageReplaceResponse),
            [ChunkCompletionResponse.Event_MessageFile] = typeof(ChunkCompletionMessageFileResponse),
            [ChunkCompletionResponse.Event_MessageEnd] = typeof(ChunkCompletionMessageEndResponse),
            [ChunkCompletionResponse.Event_WorkflowStarted] = typeof(ChunkCompletionWorkflowStartedResponse),
            [ChunkCompletionResponse.Event_WorkflowFinished] = typeof(ChunkCompletionWorkflowFinishedResponse),
            [ChunkCompletionResponse.Event_NodeStarted] = typeof(ChunkCompletionNodeStartedResponse),
            [ChunkCompletionResponse.Event_NodeFinished] = typeof(ChunkCompletionNodeFinishedResponse),
            [ChunkCompletionResponse.Event_AgentMessage] = typeof(ChunkCompletionAgentMessageResponse),
            [ChunkCompletionResponse.Event_AgentThought] = typeof(ChunkCompletionAgentThoughtResponse),
            [ChunkCompletionResponse.Event_Error] = typeof(ChunkCompletionErrorResponse),
        };

        public ChunkCompletionResponseConverter() : base("event", _derivedTypes)
        {
        }
    }
}

