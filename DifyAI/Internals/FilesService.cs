using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DifyAI.Interfaces;

namespace DifyAI.Internals
{
    partial class DifyAIService: IFilesService
    {
        public async Task<UploadResponse> UploadAsync(UploadRequest request, CancellationToken cancellationToken = default)
        {
            using var formData = new MultipartFormDataContent();
            using var fileStream = File.OpenRead(request.File);
            using var streamContent = new StreamContent(fileStream);

            using var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png"); // 根据文件实际类型设置

            formData.Add(fileContent, "file", Path.GetFileName(request.File));
            formData.Add(new StringContent(request.User), "user");

            return await _httpClient.UploadAsAsync<UploadResponse>("files/upload", formData, request, cancellationToken);
        }
    }
}
