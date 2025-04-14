using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetRetrieveRequest: RequestBase
{
    /// <summary>
    ///     Dataset Id
    /// </summary>
    [JsonIgnore]
    public string DatasetId { get; set; }
    
    /// <summary>
    /// 检索关键词
    /// </summary>
    [JsonPropertyName("query")]
    public string Query { get; set; }

    /// <summary>
    /// 检索参数（选填，如不填，按照默认方式召回）
    /// </summary>
    [JsonPropertyName(("retrieval_model"))]
    public DatasetRetrievalModel RetrievalModel { get; set; }
}