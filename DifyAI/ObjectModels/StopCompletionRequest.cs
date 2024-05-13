using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class StopCompletionRequest: RequestBase
    {
        /// <summary>
        /// 任务 ID，可在流式返回 Chunk 中获取
        /// </summary>
        [Required]
        [JsonIgnore]
        public string TaskId { get; set; }

        /// <summary>
        /// 用户标识，用于定义终端用户的身份，必须和发送消息接口传入 user 保持一致。
        /// </summary>
        [Required]
        [JsonPropertyName("user")]
        public string User { get; set; }
    }
}
