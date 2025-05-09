using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentListResponse : ResponseBase
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
        /// 总页数
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// 当前页数
        /// </summary>
        [JsonPropertyName("page")]
        public int Page { get; set; }

        /// <summary>
        /// 文件列表
        /// </summary>
        [JsonPropertyName("data")]
        public IReadOnlyList<DatasetDocument> Data { get; set; }
    }
}
