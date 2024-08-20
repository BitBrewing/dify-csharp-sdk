using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentSegmentListRequest : RequestBase
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
        ///    keyword，choosable
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        ///   Search status，completed
        /// </summary>
        public string Status { get; set; } = "completed";
    }
}
