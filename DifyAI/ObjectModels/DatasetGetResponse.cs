using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using DifyAI.Json;

namespace DifyAI.ObjectModels;

public class DatasetGetResponse: ResponseBase
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("provider")]
    public string Provider { get; set; }

    [JsonPropertyName("permission")]
    public string Permission { get; set; }

    [JsonPropertyName("data_source_type")]
    public string DataSourceType { get; set; }

    [JsonPropertyName("indexing_technique")]
    public string IndexingTechnique { get; set; }

    [JsonPropertyName("app_count")]
    public int AppCount { get; set; }

    [JsonPropertyName("document_count")]
    public int DocumentCount { get; set; }

    [JsonPropertyName("word_count")]
    public int WordCount { get; set; }

    [JsonPropertyName("created_by")]
    public string CreatedBy { get; set; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(UnixTimestampConverter))]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("updated_by")]
    public string UpdatedBy { get; set; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(UnixTimestampNullConverter))]
    public DateTimeOffset? UpdatedAt { get; set; }

    [JsonPropertyName("embedding_model")]
    public string EmbeddingModel { get; set; }

    [JsonPropertyName("embedding_model_provider")]
    public string EmbeddingModelProvider { get; set; }

    [JsonPropertyName("embedding_available")]
    public bool EmbeddingAvailable { get; set; }

    [JsonPropertyName("retrieval_model_dict")]
    public DatasetRetrievalModelDict RetrievalModelDict { get; set; }

    [JsonPropertyName("tags")]
    public IReadOnlyList<string> Tags { get; set; }

    [JsonPropertyName("doc_form")]
    public string DocForm { get; set; }

    [JsonPropertyName("external_knowledge_info")]
    public DatasetExternalKnowledgeInfo ExternalKnowledgeInfo { get; set; }

    [JsonPropertyName("external_retrieval_model")]
    public DatasetExternalRetrievalModel ExternalRetrievalModel { get; set; }
}