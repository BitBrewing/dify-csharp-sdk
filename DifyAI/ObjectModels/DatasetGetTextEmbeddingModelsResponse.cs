using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetGetTextEmbeddingModelsResponse: ResponseBase
{
    [JsonPropertyName("data")]
    public IReadOnlyList<DatasetTextEmbeddingModelData> Data { get; set; }
}