using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DatasetCreateRequest : RequestBase
    {
        /// <summary>
        /// Name of the dataset
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// 知识库描述（选填）
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// 索引模式
        /// <list type="bullet">
        /// <item>high_quality - 高质量模式</item>
        /// <item>economy - 经济模式</item>
        /// </list>
        /// （选填，建议填写）
        /// </summary>
        [JsonPropertyName("indexing_technique")]
        public string IndexingTechnique { get; set; }
        
        /// <summary>
        /// 权限（选填）
        /// <list type="bullet">
        /// <item>only_me - 仅自己（默认值）</item>
        /// <item>all_team_members - 所有团队成员</item>
        /// <item>partial_members - 部分团队成员</item>
        /// </list>
        /// </summary>
        [JsonPropertyName("permission")]
        public string Permission { get; set; }
        
        /// <summary>
        /// Provider（选填）
        /// <list type="bullet">
        /// <item>vendor - 上传文件（默认值）</item>
        /// <item>external - 外部知识库</item>
        /// </list>
        /// </summary>
        [JsonPropertyName("provider")]
        public string Provider { get; set; }
        
        /// <summary>
        /// 外部知识库 API_ID（选填）
        /// </summary>
        [JsonPropertyName("external_knowledge_api_id")]
        public string ExternalKnowledgeApiId { get; set; }
        
        /// <summary>
        /// 外部知识库 ID（选填）
        /// </summary>
        [JsonPropertyName("external_knowledge_id")]
        public string ExternalKnowledgeId { get; set; }
    }
}
