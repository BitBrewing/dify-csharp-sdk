using DifyAI.ObjectModels;

namespace DifyAI.Test
{
    public class ApplicationsTest : TestBase
    {
        [Fact]
        public async Task Parameters()
        {
            var rsp = await _difyAIService.Applications.ParametersAsync(new ApplicationParametersRequest{
                User = "user123"
            });
        }

        [Fact]
        public async Task Meta()
        {
            var rsp = await _difyAIService.Applications.MetaAsync(new ApplicationMetaRequest{
                User = "user123"
            });
        }
    }
}