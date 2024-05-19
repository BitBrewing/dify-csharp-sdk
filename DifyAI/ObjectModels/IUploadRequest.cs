using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    internal interface IUploadRequest: IRequest
    {
        /// <summary>
        /// 要上传的文件
        /// </summary>
        string File { get; }
    }
}
