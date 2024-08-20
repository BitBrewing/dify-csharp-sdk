using DifyAI.Json;
using System;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DatasetResponse
    {
        /// <summary>
        /// ID of the dataset
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the dataset
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the dataset
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Provider of the dataset
        /// </summary>
        [JsonPropertyName("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Permission of the dataset
        /// </summary>
        [JsonPropertyName("permission")]
        public string Permission { get; set; }

        /// <summary>
        /// Type of the dataset
        /// </summary>
        [JsonPropertyName("data_source_type")]
        public string DataSourceType { get; set; }

        /// <summary>
        /// indexing technique
        /// </summary>
        [JsonPropertyName("indexing_technique")]
        public string IndexingTechnique { get; set; }

        /// <summary>
        /// App count
        /// </summary>
        [JsonPropertyName("app_count")]
        public int? AppCount { get; set; }

        /// <summary>
        /// Document count
        /// </summary>
        [JsonPropertyName("document_count")]
        public int? DocumentCount { get; set; }

        /// <summary>
        /// Word count
        /// </summary>
        [JsonPropertyName("word_count")]
        public int? WordCount { get; set; }

        /// <summary>
        /// Created By
        /// </summary>
        [JsonPropertyName("created_by")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Created At
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixTimestampNullConverter))]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// Updated By
        /// </summary>
        [JsonPropertyName("updated_by")]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Updated At
        /// </summary>
        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(UnixTimestampNullConverter))]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// Embedding model
        /// </summary>
        [JsonPropertyName("embedding_model")]
        public string EmbeddingModel { get; set; }

        /// <summary>
        /// Embedding model provider
        /// </summary>
        [JsonPropertyName("embedding_model_provider")]
        public string EmbeddingModelProvider { get; set; }

        /// <summary>
        /// Embedding available
        /// </summary>
        [JsonPropertyName("embedding_available")]
        public bool? EmbeddingAvailable { get; set; }
    }
}
