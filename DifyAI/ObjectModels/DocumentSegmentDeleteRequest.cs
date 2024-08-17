using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentSegmentDeleteRequest : RequestBase
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
    }

}
