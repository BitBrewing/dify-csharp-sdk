using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetExternalKnowledgeInfo
{
    [JsonPropertyName("external_knowledge_id")]
    public string ExternalKnowledgeId { get; set; }

    [JsonPropertyName("external_knowledge_api_id")]
    public string ExternalKnowledgeApiId { get; set; }

    [JsonPropertyName("external_knowledge_api_name")]
    public string ExternalKnowledgeApiName { get; set; }

    [JsonPropertyName("external_knowledge_api_endpoint")]
    public string ExternalKnowledgeApiEndpoint { get; set; }
}