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
                File = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Assets/Image.png"),
                User = "user123",
            };

            var rsp = await _difyAIService.Files.UploadAsync(req);
            Assert.NotNull(rsp.Id);
        }
	}
}