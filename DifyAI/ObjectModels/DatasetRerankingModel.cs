using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetRerankingModel
{
    /// <summary>
    /// Rerank 模型的提供商
    /// </summary>
    [JsonPropertyName("reranking_provider_name")]
    public string RerankingProviderName { get; set; }
    
    /// <summary>
    /// Rerank 模型的名称
    /// </summary>
    [JsonPropertyName("reranking_model_name")]
    public string RerankingModelName { get; set; }
}