using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class UploadRequest: RequestBase, IUploadRequest
    {
        /// <summary>
        /// 要上传的文件
        /// </summary>
        [Required]
        public string File { get; set; }

        /// <summary>
        /// 用户标识，用于定义终端用户的身份，必须和发送消息接口传入 user 保持一致。
        /// </summary>
        [Required]
        public string User { get; set; }

        void IUploadRequest.PrepareContent(MultipartFormDataContent formDataContent, HttpContent fileContent)
        {
            formDataContent.Add(fileContent, "file", Path.GetFileName(File));
            formDataContent.Add(new StringContent(User), "user");
        }
    }
}
