using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentSegmentAddRequest : RequestBase
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
        /// Segments to add
        /// </summary>
        [JsonPropertyName("segments")]
        public List<DocumentSegmentToAdd> Segments { get; set; }
    }

    public class DocumentSegmentToAdd
    {
        /// <summary>
        /// Text content/question content, required
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }

        /// <summary>
        /// Answer content, if the mode of the Knowledge is qa mode, pass the value(optional)
        /// </summary>
        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        /// <summary>
        ///     Keywords(optional)
        /// </summary>
        [JsonPropertyName("keywords")]
        public List<string> Keywords { get; set; }
    }
}
