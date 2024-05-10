using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using DifyAI.ObjectModels;
using DifySdk.Dtos;

namespace DifyAI.Converters
{
    internal class ChatCompletionStreamResponseConverter : PolymorphicConverterBase<CreateCompletionStreamResponse>
    {
        private static readonly Dictionary<string, Type> _derivedTypes = new()
        {
            [CreateCompletionStreamResponse.Event_Message] = typeof(CreateCompletionStreamMessageResponse),
            [CreateCompletionStreamResponse.Event_MessageEnd] = typeof(CreateCompletionStreamMessageEndResponse),
            [CreateCompletionStreamResponse.Event_WorkflowStarted] = typeof(CreateCompletionStreamWorkflowStartedResponse),
            [CreateCompletionStreamResponse.Event_WorkflowFinished] = typeof(CreateCompletionStreamWorkflowFinishedResponse),
            [CreateCompletionStreamResponse.Event_NodeStarted] = typeof(CreateCompletionStreamNodeStartedResponse),
            [CreateCompletionStreamResponse.Event_NodeFinished] = typeof(CreateCompletionStreamNodeFinishedResponse),
            [CreateCompletionStreamResponse.Event_Error] = typeof(CreateCompletionStreamErrorResponse),
        };

        public ChatCompletionStreamResponseConverter() : base("event", _derivedTypes)
        {
        }
    }
}

