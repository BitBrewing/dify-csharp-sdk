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
                File = @"C:\Users\obsgo\Pictures\36703881.png",
                User = "user123",
            };

            var rsp = await _difyAIService.Files.UploadAsync(req);
            Assert.NotEmpty(rsp.Name);
        }
	}
}

