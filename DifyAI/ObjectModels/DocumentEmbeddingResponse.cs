using DifyAI.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentEmbeddingResponse
    {
        /// <summary>
        ///     document embedding progress status
        /// </summary>
        [JsonPropertyName("data")]
        public IReadOnlyList<DocumentEmbeddingStatus> Data { get; set; }
    }

    public class DocumentEmbeddingStatus
    {
        /// <summary>
        /// ID of the document embedding task
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Indexing status
        /// </summary>
        [JsonPropertyName("indexing_status")]
        public string IndexingStatus { get; set; }

        /// <summary>
        /// Processing Started At
        /// </summary>
        [JsonPropertyName("processing_started_at")]
        [JsonConverter(typeof(UnixTimestampNullConverter))]
        public DateTimeOffset? ProcessingStartedAt { get; set; }

        /// <summary>
        /// Parsing Completed At
        /// </summary>
        [JsonPropertyName("parsing_completed_at")]
        [JsonConverter(typeof(UnixTimestampNullConverter))]
        public DateTimeOffset? ParsingCompletedAt { get; set; }

        /// <summary>
        /// Cleaning Completed At
        /// </summary>
        [JsonPropertyName("cleaning_completed_at")]
        [JsonConverter(typeof(UnixTimestampNullConverter))]
        public DateTimeOffset? CleaningCompletedAt { get; set; }

        /// <summary>
        /// Splitting completed at
        /// </summary>
        [JsonPropertyName("splitting_completed_at")]
        [JsonConverter(typeof(UnixTimestampNullConverter))]
        public DateTimeOffset? SplittingCompletedAt { get; set; }

        /// <summary>
        /// Completed At
        /// </summary>
        [JsonPropertyName("completed_at")]
        [JsonConverter(typeof(UnixTimestampNullConverter))]
        public DateTimeOffset? CompletedAt { get; set; }

        /// <summary>
        /// Paused At
        /// </summary>
        [JsonPropertyName("paused_at")]
        [JsonConverter(typeof(UnixTimestampNullConverter))] 
        public DateTimeOffset? PausedAt { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        [JsonPropertyName("error")] 
        public string Error { get; set; }

        /// <summary>
        /// Stopped At
        /// </summary>
        [JsonPropertyName("stopped_at")]
        [JsonConverter(typeof(UnixTimestampNullConverter))]
        public DateTimeOffset? StoppedAt { get; set; }

        /// <summary>
        /// Completed Segments
        /// </summary>
        [JsonPropertyName("completed_segments")] 
        public int? CompletedSegments { get; set; }

        /// <summary>
        /// Total Segments
        /// </summary>
        [JsonPropertyName("total_segments")] 
        public int? TotalSegments { get; set; }

    }

}
