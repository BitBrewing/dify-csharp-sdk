using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DifyAI.Interfaces;

namespace DifyAI.Services
{
    partial class DifyAIService: IFilesService
    {
        public async Task<FileUploadResponse> UploadAsync(FileUploadRequest request, CancellationToken cancellationToken = default)
        {
            return await _httpClient.UploadAsAsync<FileUploadResponse>("files/upload", request, cancellationToken);
        }
    }
}
