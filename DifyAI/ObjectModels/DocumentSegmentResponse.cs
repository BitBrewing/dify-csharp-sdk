using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentSegmentResponse : ResponseBase
    {
        /// <summary>
        ///     document embedding progress status
        /// </summary>
        [JsonPropertyName("data")]
        public IReadOnlyList<DocumentSegmentsItem> Data { get; set; }

        [JsonPropertyName("doc_form")]
        public string DocForm { get; set; }
    }

    public class DocumentSegmentUpdateResponse : ResponseBase
    {
        /// <summary>
        ///     document embedding progress status
        /// </summary>
        [JsonPropertyName("data")]
        public DocumentSegmentsItem Data { get; set; }

        [JsonPropertyName("doc_form")]
        public string DocForm { get; set; }
    }
}
