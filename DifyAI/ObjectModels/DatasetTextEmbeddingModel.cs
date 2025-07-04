using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetTextEmbeddingModel
{
    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("label")]
    public DatasetTextEmbeddingModelLabel Label { get; set; }

    [JsonPropertyName("model_type")]
    public string ModelType { get; set; }

    [JsonPropertyName("features")]
    public string Features { get; set; }

    [JsonPropertyName("fetch_from")]
    public string FetchFrom { get; set; }

    [JsonPropertyName("model_properties")]
    public Dictionary<string, object> ModelProperties { get; set; }

    [JsonPropertyName("deprecated")]
    public bool Deprecated { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("load_balancing_enabled")]
    public bool LoadBalancingEnabled { get; set; }
}