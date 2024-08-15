using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class RetrieverResource
    {
        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("dataset_id")]
        public string DatasetId { get; set; }

        [JsonPropertyName("dataset_name")]
        public string DatasetName { get; set; }

        [JsonPropertyName("document_id")]
        public string DocumentId { get; set; }

        [JsonPropertyName("document_name")]
        public string DocumentName { get; set; }

        [JsonPropertyName("data_source_type")]
        public string DataSourceType { get; set; }

        [JsonPropertyName("segment_id")]
        public string SegmentId { get; set; }

        [JsonPropertyName("retriever_from")]
        public string RetrieverFrom { get; set; }

        [JsonPropertyName("score")]
        public float? Score { get; set; }

        [JsonPropertyName("hit_count")]
        public int HitCount { get; set; }

        [JsonPropertyName("word_count")]
        public int WordCount { get; set; }

        [JsonPropertyName("segment_position")]
        public int SegmentPosition { get; set; }

        [JsonPropertyName("index_node_hash")]
        public string IndexNodeHash { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
