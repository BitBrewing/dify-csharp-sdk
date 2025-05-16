using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetTextEmbeddingModelData
{
    [JsonPropertyName("provider")]
    public string Provider { get; set; }

    [JsonPropertyName("label")]
    public DatasetTextEmbeddingModelLabel Label { get; set; }

    [JsonPropertyName("icon_small")]
    public DatasetTextEmbeddingModelIcon IconSmall { get; set; }

    [JsonPropertyName("icon_large")]
    public DatasetTextEmbeddingModelIcon IconLarge { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("models")]
    public IReadOnlyList<DatasetTextEmbeddingModel> Models { get; set; }
}