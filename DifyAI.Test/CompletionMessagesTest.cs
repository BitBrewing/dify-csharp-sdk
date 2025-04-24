using DifyAI.ObjectModels;

namespace DifyAI.Test;

public class CompletionMessagesTest: TestBase
{
    [Fact]
    public async Task CompletionAsync()
    {
        var req = new CompletionRequest
        {
            ApiKey = "app-vvEU80qX2dGBbjKTQJTqr0HW",
            User = "user123",
            Inputs =
            {
                ["query"] = "你好"
            }
        };
        var rsp = await _difyAIService.CompletionMessages.CompletionAsync(req);
        Assert.NotNull(rsp.MessageId);
    }
}