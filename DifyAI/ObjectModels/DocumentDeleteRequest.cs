using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentDeleteRequest: RequestBase
    {
        /// <summary>
        /// Dataset ID
        /// </summary>
        [JsonIgnore]
        public string DatasetId { get; set; }

        /// <summary>
        /// Document ID
        /// </summary>
        [JsonIgnore]
        public string DocumentId { get; set; }
    }
}
