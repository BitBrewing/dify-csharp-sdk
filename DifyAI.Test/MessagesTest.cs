using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyAI.Test
{
    public class MessagesTest: TestBase
    {
        [Fact]
        public async Task History()
        {
            var req = new MessageHistoryRequest
            {
                ConversationId = "4cb6528f-fa51-46bc-ab11-604ca69b56db",
                User = "user123",
            };
            var rsp = await _difyAIService.Messages.HistoryAsync(req);

        }

        [Fact]
        public async Task Suggested()
        {
            var message = await _difyAIService.ChatMessages.ChatAsync(new ChatCompletionRequest
            {
                Query = "who are you?",
                User = "user123",
            });
            var suggested = await _difyAIService.Messages.SuggestedAsync(new MessageSuggestedRequest
            {
                MessageId = message.MessageId,
                User = "user123",
            });
            Assert.NotNull(suggested.Data);
        }
    }
}
