using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetRecord
{
    [JsonPropertyName("segment")]
    public DocumentSegmentsItem Segment { get; set; }

    [JsonPropertyName("score")]
    public float Score { get; set; }
}