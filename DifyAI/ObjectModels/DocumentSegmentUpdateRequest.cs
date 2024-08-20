using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentSegmentUpdateRequest : RequestBase
    {
        /// <summary>
        ///     Dataset Id
        /// </summary>
        [JsonIgnore]
        public string DatasetId { get; set; }

        /// <summary>
        ///     Document Id
        /// </summary>
        [JsonIgnore]
        public string DocumentId { get; set; }

        /// <summary>
        ///     Segment Id
        /// </summary>
        [JsonIgnore]
        public string SegmentId { get; set; }

        [JsonPropertyName("segment")]
        public DocumentSegmentToUpdate Segment { get; set; }
    }

    public class DocumentSegmentToUpdate: DocumentSegmentToAdd
    {
        /// <summary>
        ///     (bool) false/true, not required
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; }
    }
}
