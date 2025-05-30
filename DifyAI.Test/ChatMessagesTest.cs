﻿using DifyAI.Interfaces;
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
                ApiKey = "app-Bmqhdl4yuJypTwuIslmdgMyy",
                Query = "你好",
                User = "user123",
                Inputs = new Dictionary<string, string>
                {
                    ["Name"] = "Name",
                },
            };
            var rsp = await _difyAIService.ChatMessages.ChatAsync(req);
            Assert.NotNull(rsp.MessageId);
        }

        [Fact]
        public async Task StartChat()
        {
            var fileId = await UploadAsync();

            var req = new ChatCompletionRequest
            {
                Query = "你好",
                User = "user123",
                Files = new CompletionFile[]
                {
                    new CompletionFile {
                        Type = "image",
                        TransferMethod  = "local_file",
                        UploadFileId = fileId,
                    }
                }
            };

            await foreach (var rsp in _difyAIService.ChatMessages.ChatStreamAsync(req))
            {
                Assert.NotNull(rsp.Event);
            }
        }

        private async Task<string> UploadAsync()
        {
            var req = new FileUploadRequest
            {
                File = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Assets/Image.png"),
                User = "user123",
            };

            var rsp = await _difyAIService.Files.UploadAsync(req);
            return rsp.Id;
        }
    }
}
