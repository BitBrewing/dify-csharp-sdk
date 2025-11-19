using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    internal interface IUploadRequest: IRequest
    {
        /// <summary>
        /// 要上传的文件(与 FileStream 选其一)
        /// </summary>
        string File { get; }
        
        /// <summary>
        /// 要上传的文件流(与 File 选其一)
        /// </summary>
        Stream FileStream { get; }
    }
}
