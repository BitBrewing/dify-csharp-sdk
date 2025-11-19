using System;
using System.IO;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
	public class AudioToTextRequest: RequestBase, IUploadRequest
	{
        /// <summary>
        /// 语音文件。 支持格式：['mp3', 'mp4', 'mpeg', 'mpga', 'm4a', 'wav', 'webm'] 文件大小限制：15MB
        /// </summary>
        [JsonIgnore]
        public string File { get; set; }

        /// <summary>
        /// 语音文件流。 支持格式：['mp3', 'mp4', 'mpeg', 'mpga', 'm4a', 'wav', 'webm'] 文件大小限制：15MB
        /// </summary>
        [JsonIgnore]
        public Stream FileStream { get; }

        /// <summary>
        /// 用户标识，用于定义终端用户的身份，必须和发送消息接口传入 user 保持一致。
        /// </summary>
        [JsonPropertyName("user")]
        public string User { get; set; }
    }
}

