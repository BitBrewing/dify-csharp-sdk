using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class FileUploadOptions
    {
        /// <summary>
        /// 图片设置 当前仅支持图片类型：png, jpg, jpeg, webp, gif
        /// </summary>
        [JsonPropertyName("image")]
        public FileUploadImageParameterOptions Image { get; set; }
    }

    public class FileUploadImageParameterOptions : ParameterOptions
    {
        /// <summary>
        /// 图片数量限制，默认 3
        /// </summary>
        [JsonPropertyName("number_limits")]
        public int NumberLimits { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("detail")]
        public string Detail { get; set; }

        /// <summary>
        /// 传递方式列表，remote_url , local_file，必选一个
        /// </summary>
        [JsonPropertyName("transfer_methods")]
        public IReadOnlyList<string> TransferMethods { get; set; }
    }
}