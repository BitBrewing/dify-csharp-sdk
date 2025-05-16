using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetGetRequest: RequestBase
{
    /// <summary>
    /// 知识库 ID
    /// </summary>
    [JsonIgnore]
    public string DatasetId { get; set; }
}