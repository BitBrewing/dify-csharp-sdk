using DifyAI.Interfaces;
using DifyAI.ObjectModels;
using DifySdk.Dtos;
using Microsoft.Extensions.DependencyInjection;
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

            await foreach (var rsp in _difyAIService.ChatMessages.StartChatAsync(req))
            {
                Assert.NotNull(rsp.Event);
            }
        }
    }
}
