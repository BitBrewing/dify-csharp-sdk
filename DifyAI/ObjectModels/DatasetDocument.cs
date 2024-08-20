using DifyAI.Json;
using System;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DatasetDocument
    {
        /// <summary>
        /// ID of the dataset document
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Position of the dataset document
        /// </summary>
        [JsonPropertyName("position")]
        public int Position { get; set; }

        /// <summary>
        /// Type of the dataset document
        /// </summary>
        [JsonPropertyName("data_source_type")]
        public string DataSourceType { get; set; }

        /// <summary>
        /// Data source info of the dataset document
        /// </summary>
        [JsonPropertyName("data_source_info")]
        public DatasetDocumentDataSourceInfo DataSourceInfo { get; set; }

        /// <summary>
        /// Dataset process rule ID
        /// </summary>
        [JsonPropertyName("dataset_process_rule_id")]
        public string DatasetProcessRuleId { get; set; }

        /// <summary>
        /// Name of the dataset document
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Created from
        /// </summary>
        [JsonPropertyName("created_from")]
        public string CreatedFrom { get; set; }

        /// <summary>
        /// Created by
        /// </summary>
        [JsonPropertyName("created_by")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Created at
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixTimestampNullConverter))]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// Token count
        /// </summary>
        [JsonPropertyName("tokens")]
        public int? Tokens { get; set; }

        /// <summary>
        /// Indexing status
        /// </summary>
        [JsonPropertyName("indexing_status")]
        public string IndexingStatus { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        [JsonPropertyName("error")]
        public string Error { get; set; }

        /// <summary>
        /// Enabled
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Disabled at
        /// </summary>
        [JsonPropertyName("disabled_at")]
        [JsonConverter(typeof(UnixTimestampNullConverter))]
        public DateTimeOffset? DisabledAt { get; set; }

        /// <summary>
        /// Disabled by
        /// </summary>
        [JsonPropertyName("disabled_by")]
        public string DisabledBy { get; set; }

        /// <summary>
        /// Archived
        /// </summary>
        [JsonPropertyName("archived")]
        public bool? Archived { get; set; }

        /// <summary>
        /// Display status
        /// </summary>
        [JsonPropertyName("display_status")]
        public string DisplayStatus { get; set; }

        /// <summary>
        /// Word count
        /// </summary>
        [JsonPropertyName("word_count")]
        public int? WordCount { get; set; }

        /// <summary>
        /// Hit count
        /// </summary>
        [JsonPropertyName("hit_count")]
        public int? HitCount { get; set; }

        /// <summary>
        /// Doc form
        /// </summary>
        [JsonPropertyName("doc_form")]
        public string DocForm { get; set; }
    }

    public class DatasetDocumentDataSourceInfo
    {
        /// <summary>
        /// Upload file ID
        /// </summary>
        [JsonPropertyName("upload_file_id")]
        public string UploadFileId { get; set; }
    }
}
