using System;
using DifyAI.ObjectModels;
namespace DifyAI.Test
{
	public class FilesTest : TestBase
	{
		[Fact]
        public async Task Upload()
        {
	        await using var fileStream = File.OpenRead("path/to/file");
	        var req = new FileUploadRequest 
	        { 
		        FileStream = fileStream,
		        User = "user123",
	        };

	        await _difyAIService.Files.UploadAsync(req);
        }
	}
}