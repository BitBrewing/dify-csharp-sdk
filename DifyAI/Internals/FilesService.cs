using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            return await _httpClient.UploadAsAsync<UploadResponse>("files/upload", request, cancellationToken);
        }
    }
}
