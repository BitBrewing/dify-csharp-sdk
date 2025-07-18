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
        
        [Fact]
        public async Task Info()
        {
            var rsp = await _difyAIService.Applications.InfoAsync(new ApplicationInfoRequest{
                User = "user123"
            });
        }

        [Fact]
        public async Task Site()
        {
            var rsp = await _difyAIService.Applications.SiteAsync(new ApplicationWebappRequest
            {
                User = "user123"
            });
            Assert.NotEmpty(rsp.Title);
        }
    }
}