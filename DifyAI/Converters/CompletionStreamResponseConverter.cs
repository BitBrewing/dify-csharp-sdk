using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using DifyAI.ObjectModels;
using DifySdk.Dtos;

namespace DifyAI.Converters
{
    internal class CompletionStreamResponseConverter : PolymorphicConverterBase<CompletionStreamResponse>
    {
        private static readonly Dictionary<string, Type> _derivedTypes = new()
        {
            [CompletionStreamResponse.Event_Message] = typeof(CompletionStreamMessageResponse),
            [CompletionStreamResponse.Event_MessageFile] = typeof(CompletionStreamMessageFileResponse),
            [CompletionStreamResponse.Event_MessageEnd] = typeof(CompletionStreamMessageEndResponse),
            [CompletionStreamResponse.Event_WorkflowStarted] = typeof(CompletionStreamWorkflowStartedResponse),
            [CompletionStreamResponse.Event_WorkflowFinished] = typeof(CompletionStreamWorkflowFinishedResponse),
            [CompletionStreamResponse.Event_NodeStarted] = typeof(CompletionStreamNodeStartedResponse),
            [CompletionStreamResponse.Event_NodeFinished] = typeof(CompletionStreamNodeFinishedResponse),
            [CompletionStreamResponse.Event_Error] = typeof(CompletionStreamErrorResponse),
        };

        public CompletionStreamResponseConverter() : base("event", _derivedTypes)
        {
        }
    }
}

