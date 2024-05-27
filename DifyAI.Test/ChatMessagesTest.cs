using DifyAI.Interfaces;
using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyAI.Test
{
    public class ChatMessagesTest : TestBase
    {
        [Fact]
        public async Task Chat()
        {
            var req = new ChatCompletionRequest
            {
                Query = "你好",
                User = "user123",
                Inputs = new Dictionary<string, string>
                {
                    ["arg1"] = "1",
                    ["arg2"] = "2",
                },
            };
            var rsp = await _difyAIService.ChatMessages.ChatAsync(req);
            Assert.NotNull(rsp.MessageId);
        }

        [Fact]
        public async Task StartChat()
        {
            var req = new ChatCompletionRequest
            {
                Query = "你好",
                User = "user123",
            };

            await foreach (var rsp in _difyAIService.ChatMessages.ChatStreamAsync(req))
            {
                Assert.NotNull(rsp.Event);
            }
        }
    }
}
