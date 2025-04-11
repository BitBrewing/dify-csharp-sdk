using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetRetrievalModel
{
    /// <summary>
    /// 检索方法
    /// <list type="bullet">
    /// <item>hybrid_search 混合检索</item>
    /// <item>semantic_search 语义检索</item>
    /// <item>full_text_search 全文检索</item>
    /// </list>
    /// </summary>
    [JsonPropertyName("search_method")]
    public string SearchMethod { get; set; }
    
    /// <summary>
    /// 是否开启rerank
    /// </summary>
    [JsonPropertyName("reranking_enable")]
    public bool RerankingEnable { get; set; }
    
    /// <summary>
    /// Rerank 模型配置
    /// </summary>
    [JsonPropertyName("reranking_model")]
    public DatasetRerankingModel RerankingModel { get; set; }
    
    /// <summary>
    /// 召回条数
    /// </summary>
    [JsonPropertyName("top_k")]
    public int? TopK { get; set; }
    
    /// <summary>
    /// 是否开启召回分数限制
    /// </summary>
    [JsonPropertyName("score_threshold_enabled")]
    public bool? ScoreThresholdEnabled { get; set; }
    
    /// <summary>
    /// 召回分数限制
    /// </summary>
    [JsonPropertyName("score_threshold")]
    public float? ScoreThreshold { get; set; }
}