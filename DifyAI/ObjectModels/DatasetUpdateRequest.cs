using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetUpdateRequest: RequestBase
{
    /// <summary>
    /// 知识库 ID
    /// </summary>
    [JsonIgnore]
    public string DatasetId { get; set; }
    
    [JsonPropertyName("indexing_technique")]
    public string IndexingTechnique { get; set; }
    
    [JsonPropertyName("permission")]
    public string Permission { get; set; }
    
    [JsonPropertyName("embedding_model_provider")]
    public string EmbeddingModelProvider { get; set; }
    
    [JsonPropertyName("embedding_model")]
    public string EmbeddingModel { get; set; }
    
    [JsonPropertyName("retrieval_model_dict")]
    public DatasetRetrievalModelDict RetrievalModelDict { get; set; }
    
    [JsonPropertyName("partial_member_list")]
    public IReadOnlyList<string> PartialMemberList { get; set; }
}