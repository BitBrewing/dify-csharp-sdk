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
    public class DifyAIServiceTest
    {
        private readonly IDifyAIService _difyAIService;

        public DifyAIServiceTest()
        {
            var services = new ServiceCollection();

            services
                .AddDifyAIService(x =>
                {
                    x.BaseDomain = "http://10.13.60.91/v1";
                    x.ApiKey = "app-3ppSoe6ynEvBgTpugCyenxr6";
                });

            var app = services.BuildServiceProvider();
            _difyAIService = app.GetRequiredService<IDifyAIService>();
        }

        [Fact]
        public async Task CreateCompletion()
        {
            var req = new CreateCompletionRequest
            {
                Query = "你好",
                //User = "user123",
            };
            var rsp = await _difyAIService.ChatMessages.CreateCompletionAsync(req);
            Assert.NotNull(rsp.MessageId);
        }

        [Fact]
        public async Task CreateCompletionStream()
        {
            var req = new CreateCompletionRequest
            {
                Query = "你好",
                User = "user123",
            };

            await foreach (var rsp in _difyAIService.ChatMessages.CreateCompletionStreamAsync(req))
            {
                Assert.NotNull(rsp.Event);
            }
        }
    }
}
