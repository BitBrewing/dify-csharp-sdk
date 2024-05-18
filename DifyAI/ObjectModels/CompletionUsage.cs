using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class CompletionUsage
    {
        [JsonPropertyName("prompt_tokens")]
        public int PromptTokens { get; set; }

        [JsonPropertyName("prompt_unit_price")]
        public string PromptUnitPrice { get; set; }

        [JsonPropertyName("prompt_price_unit")]
        public string PromptPriceUnit { get; set; }

        [JsonPropertyName("prompt_price")]
        public string PromptPrice { get; set; }

        [JsonPropertyName("completion_tokens")]
        public int CompletionTokens { get; set; }

        [JsonPropertyName("completion_unit_price")]
        public string CompletionUnitPrice { get; set; }

        [JsonPropertyName("completion_price_unit")]
        public string CompletionPriceUnit { get; set; }

        [JsonPropertyName("completion_price")]
        public string CompletionPrice { get; set; }

        [JsonPropertyName("total_tokens")]
        public int TotalTokens { get; set; }

        [JsonPropertyName("total_price")]
        public string TotalPrice { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("latency")]
        public float Latency { get; set; }
    }
}
