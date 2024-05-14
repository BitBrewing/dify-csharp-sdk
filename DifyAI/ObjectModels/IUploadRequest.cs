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
        string File { get; }

        void PrepareContent(MultipartFormDataContent formDataContent, HttpContent fileContent);
    }
}
