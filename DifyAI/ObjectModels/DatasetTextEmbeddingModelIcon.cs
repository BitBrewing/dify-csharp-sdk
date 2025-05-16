using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetTextEmbeddingModelIcon
{
    [JsonPropertyName("zh_Hans")]
    public string ZhHans { get; set; }

    [JsonPropertyName("en_US")]
    public string EnUS { get; set; }
}