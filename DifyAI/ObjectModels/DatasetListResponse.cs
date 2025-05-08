using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DatasetListResponse : ResponseBase
    {
        /// <summary>
        /// 返回条数，若传入超过系统限制，返回系统限制数量
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// 是否存在下一页
        /// </summary>
        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }

        /// <summary>
        /// 会话列表
        /// </summary>
        [JsonPropertyName("data")]
        public IReadOnlyList<DatasetResponse> Data { get; set; }
    }
}
