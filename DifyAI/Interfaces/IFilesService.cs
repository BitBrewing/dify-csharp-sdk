using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI.Interfaces
{
    public interface IFilesService
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <remarks>上传文件（目前仅支持图片）并在发送消息时使用，可实现图文多模态理解。 支持 png, jpg, jpeg, webp, gif 格式。 上传的文件仅供当前终端用户使用。</remarks>
        Task<UploadResponse> UploadAsync(UploadRequest request, CancellationToken cancellationToken = default);
    }
}
