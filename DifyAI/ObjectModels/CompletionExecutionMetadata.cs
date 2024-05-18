using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class CompletionExecutionMetadata
    {
        /// <summary>
        /// 总使用 tokens
        /// </summary>
        [JsonPropertyName("total_tokens")]
        public int? TotalTokens { get; set; }

        /// <summary>
        /// 总费用
        /// </summary>
        [JsonPropertyName("total_price")]
        public decimal? TotalPrice { get; set; }

        /// <summary>
        /// 货币，如 USD / RMB
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }
}
