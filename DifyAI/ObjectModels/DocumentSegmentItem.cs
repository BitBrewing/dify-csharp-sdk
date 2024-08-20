using DifyAI.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentSegmentsItem
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        [JsonPropertyName("position")]
        public int? Position { get; set; }

        /// <summary>
        /// Document ID
        /// </summary>
        [JsonPropertyName("document_id")]
        public string DocumentId { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [JsonPropertyName("content")] 
        public string Content { get; set; }

        /// <summary>
        /// Answer
        /// </summary>
        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        /// <summary>
        /// Word count
        /// </summary>
        [JsonPropertyName("word_count")]
        public int? WordCount { get; set; }

        /// <summary>
        /// Tokens
        /// </summary>
        [JsonPropertyName("tokens")]
        public int? Tokens { get; set; }

        /// <summary>
        /// Keywords
        /// </summary>
        [JsonPropertyName("keywords")]
        public List<string> Keywords { get; set; }

        /// <summary>
        /// Index node ID
        /// </summary>
        [JsonPropertyName("index_node_id")] 
        public string IndexNodeId { get; set; }

        /// <summary>
        /// Index node hash
        /// </summary>
        [JsonPropertyName("index_node_hash")] 
        public string IndexNodeHash { get; set; }

        /// <summary>
        /// Hit count
        /// </summary>
        [JsonPropertyName("hit_count")] 
        public int? HitCount { get; set; }

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
        /// Status
        /// </summary>
        [JsonPropertyName("status")] 
        public string Status { get; set; }

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
        /// Indexing at
        /// </summary>
        [JsonPropertyName("indexing_at")]
        [JsonConverter(typeof(UnixTimestampNullConverter))]
        public DateTimeOffset? IndexingAt { get; set; }

        /// <summary>
        /// Completed at
        /// </summary>
        [JsonPropertyName("completed_at")]
        [JsonConverter(typeof(UnixTimestampNullConverter))]
        public DateTimeOffset? CompletedAt { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        [JsonPropertyName("error")] 
        public string Error { get; set; }

        /// <summary>
        /// Stopped at
        /// </summary>
        [JsonPropertyName("stopped_at")]
        [JsonConverter(typeof(UnixTimestampNullConverter))]
        public DateTimeOffset? StoppedAt { get; set; }
    }

}
