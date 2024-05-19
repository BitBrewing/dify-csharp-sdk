using System;
using DifyAI.ObjectModels;
namespace DifyAI.Test
{
	public class FilesTest : TestBase
	{
		[Fact]
        public async Task Upload()
        {
            var req = new FileUploadRequest
            {
                File = "/Users/liuning/Pictures/08101559830054.jpeg",
                User = "user123",
            };

            var rsp = await _difyAIService.Files.UploadAsync(req);
            Assert.NotEqual(Guid.Empty ,rsp.Id);
        }
	}
}