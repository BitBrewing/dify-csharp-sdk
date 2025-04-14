using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetQuery
{
    [JsonPropertyName("content")]
    public string Content { get; set; }
}