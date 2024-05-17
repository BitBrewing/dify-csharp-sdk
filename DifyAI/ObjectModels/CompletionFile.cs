using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class CompletionFile
    {
        /// <summary>
        /// 支持类型：图片 image（目前仅支持图片格式） 。
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// 传递方式
        /// <list type="number">
        /// <item>remote_url: 图片地址。</item>
        /// <item>local_file: 上传文件。</item>
        /// </list>
        /// </summary>
        [JsonPropertyName("transfer_method")]
        public string TransferMethod { get; set; }

        /// <summary>
        /// 图片地址。（仅当传递方式为 remote_url 时）。
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// 上传文件 ID。（仅当传递方式为 local_file 时）。
        /// </summary>
        [JsonPropertyName("upload_file_id")]
        public string UploadFileId { get; set; }
    }
}
