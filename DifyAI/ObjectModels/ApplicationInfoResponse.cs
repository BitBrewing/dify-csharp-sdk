using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class ApplicationInfoResponse : ResponseBase
{
    /// <summary>
    /// 应用名称
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// 应用描述
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// 应用标签
    /// </summary>
    [JsonPropertyName("tags")]
    public IReadOnlyList<string> Tags { get; set; }
}