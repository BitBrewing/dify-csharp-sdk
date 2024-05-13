using DifyAI.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class UploadResponse
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 文件大小（byte）
        /// </summary>
        [JsonPropertyName("size")]
        public int Size { get; set; }

        /// <summary>
        /// 文件后缀
        /// </summary>
        [JsonPropertyName("extension")]
        public string Extension{ get; set; }

        /// <summary>
        /// 文件 mime-type
        /// </summary>
        [JsonPropertyName("mime_type")]
        public string MimeType { get; set; }

        /// <summary>
        /// 上传人 ID
        /// </summary>
        [JsonPropertyName("created_by")]
        public Guid CreatedBy { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
