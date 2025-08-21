using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class MessageFile
    {
        /// <summary>
        /// 文件 ID。
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 文件名。
        /// </summary>
        [JsonPropertyName("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// 文件类型，如 document、image 等。
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// 文件预览地址。
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// 文件 MIME 类型。
        /// </summary>
        [JsonPropertyName("mime_type")]
        public string MimeType { get; set; }

        /// <summary>
        /// 文件大小（字节）。
        /// </summary>
        [JsonPropertyName("size")]
        public long Size { get; set; }

        /// <summary>
        /// 文件传输方式。
        /// </summary>
        [JsonPropertyName("transfer_method")]
        public string TransferMethod { get; set; }

        /// <summary>
        /// 文件归属方，user 或 assistant。
        /// </summary>
        [JsonPropertyName("belongs_to")]
        public string BelongsTo { get; set; }

        /// <summary>
        /// 上传文件的 ID。
        /// </summary>
        [JsonPropertyName("upload_file_id")]
        public string UploadFileId { get; set; }
    }
}
