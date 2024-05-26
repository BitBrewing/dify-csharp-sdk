using DifyAI.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class CompletionNodeFinishedData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("predecessor_node_id")]
        public string PredecessorNodeId { get; set; }

        [JsonPropertyName("inputs")]
        public JsonDocument Inputs { get; set; }

        [JsonPropertyName("process_data")]
        public JsonDocument ProcessData { get; set; }

        [JsonPropertyName("outputs")]
        public JsonDocument Outputs { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("elapsed_time")]
        public float ElapsedTime { get; set; }

        [JsonPropertyName("execution_metadata")]
        public CompletionExecutionMetadata ExecutionMetadata { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
