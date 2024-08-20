using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentEmbeddingRequest : RequestBase
    {
        /// <summary>
        ///     Dataset Id
        /// </summary>
        [JsonIgnore]
        public string DatasetId { get; set; }

        /// <summary>
        ///     Batch number of uploaded documents
        /// </summary>
        [JsonIgnore]
        public string Batch { get; set; }
    }
}
