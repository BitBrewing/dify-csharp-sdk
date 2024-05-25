using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class SystemParametersOptions
    {
        /// <summary>
        ///  图片文件上传大小限制（MB）
        /// </summary>
        [JsonPropertyName("image_file_size_limit")]
        public string ImageFileSizeLimit { get; set; }
    }
}
