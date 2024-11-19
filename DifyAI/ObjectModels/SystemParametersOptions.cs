using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class SystemParametersOptions
    {
        /// <summary>
        ///  图片文件上传大小限制（MB）
        /// </summary>
        [JsonPropertyName("image_file_size_limit")]
        public int ImageFileSizeLimit { get; set; }
        
        [JsonPropertyName("video_file_size_limit")]
        public int VideoFileSizeLimit { get; set; }
        
        [JsonPropertyName("audio_file_size_limit")]
        public int AudioFileSizeLimit { get; set; }
        
        [JsonPropertyName("file_size_limit")]
        public int FileSizeLimit { get; set; }
        
        [JsonPropertyName("workflow_file_upload_limit")]
        public int WorkflowFileUploadLimit { get; set; }
    }
}
