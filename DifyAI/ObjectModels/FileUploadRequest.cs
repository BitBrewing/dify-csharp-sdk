using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class FileUploadRequest : RequestBase, IUploadRequest
    {
        /// <summary>
        /// 要上传的文件
        /// </summary>
        [JsonIgnore]
        public string File { get; set; }

        /// <summary>
        /// 用户标识，用于定义终端用户的身份，必须和发送消息接口传入 user 保持一致。
        /// </summary>
        [JsonPropertyName("user")]
        public string User { get; set; }
    }
}
