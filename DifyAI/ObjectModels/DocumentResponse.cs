using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentResponse
    {
        /// <summary>
        /// Document
        /// </summary>
        [JsonPropertyName("document")]
        public DatasetDocument Document { get; set; }

        /// <summary>
        /// Batch number of uploaded documents
        /// </summary>
        [JsonPropertyName("batch")]
        public string Batch { get; set; }
    }
}
