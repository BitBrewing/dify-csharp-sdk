using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetExternalRetrievalModel
{
    [JsonPropertyName("top_k")]
    public int? TopK { get; set; }

    [JsonPropertyName("score_threshold")]
    public float? ScoreThreshold { get; set; }

    [JsonPropertyName("score_threshold_enabled")]
    public bool? ScoreThresholdEnabled { get; set; }
}