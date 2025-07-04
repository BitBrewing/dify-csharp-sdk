using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetRetrievalModelDict
{
    [JsonPropertyName("search_method")]
    public string SearchMethod { get; set; }

    [JsonPropertyName("reranking_enable")]
    public bool RerankingEnable { get; set; }

    [JsonPropertyName("reranking_mode")]
    public string RerankingMode { get; set; }

    [JsonPropertyName("reranking_model")]
    public DatasetRerankingModel RerankingModel { get; set; }

    [JsonPropertyName("weights")]
    public float? Weights { get; set; }

    [JsonPropertyName("top_k")]
    public int? TopK { get; set; }

    [JsonPropertyName("score_threshold_enabled")]
    public bool? ScoreThresholdEnabled { get; set; }

    [JsonPropertyName("score_threshold")]
    public float? ScoreThreshold { get; set; }
}