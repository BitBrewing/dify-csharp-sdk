using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyAI.Test
{
    public class ConversationsTest: TestBase
    {
        [Fact]
        public async Task List()
        {
            var req = new ConversationListRequest
            {
                User = "user123",
            };
            var rsp = await _difyAIService.Conversations.ListAsync(req);
        }

        [Fact]
        public async Task Delete()
        {
            var req = new ConversationDeleteRequest
            {
                User  ="user123",
                ConversationId = "cfeae134-e5eb-4cb8-a075-4801452011ad"
            };
            await _difyAIService.Conversations.DeleteAsync(req);
        }

        [Fact]
        public async Task Rename()
        {
            var req = new ConversationRenameRequest
            {
                User = "user123",
                ConversationId = "4cb6528f-fa51-46bc-ab11-604ca69b56db",
                Name = "test",
            };
            await _difyAIService.Conversations.RenameAsync(req);
        }
    }
}
