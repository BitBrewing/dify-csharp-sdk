using DifyAI.ObjectModels;

namespace DifyAI.Test;

public class WorkflowsTest: TestBase
{
    [Fact]
    public async Task WorkflowStream_StartAndStop()
    {
        var req = new CompletionRequest
        {
            Inputs = new Dictionary<string, string>
            {
                { "content", "What is the capital of France?" }
            },
            User = "user123"
        };
        await foreach (var rsp in _difyAIService.Workflows.WorkflowStreamAsync(req))
        {
            if (rsp is ChunkCompletionWorkflowStartedResponse start)
            {
                await _difyAIService.Workflows.StopWorkflowAsync(new StopCompletionRequest
                {
                    User = "user123",
                    TaskId = start.TaskId,
                });
            }
            
            Assert.NotNull(rsp.Event);
        }
    }
}