using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentListRequest
    {
        /// <summary>
        /// Dataset ID
        /// </summary>
        [JsonIgnore]
        public string DatasetId { get; set; }

        /// <summary>
        /// Search keywords, currently only search document names(optional)
        /// </summary>
        [JsonIgnore]
        public string Keyword { get; set; }

        /// <summary>
        /// Page number(optional)
        /// </summary>
        [JsonIgnore]
        public int? Page { get; set; }

        /// <summary>
        /// Number of items returned, default 20, range 1-100(optional)
        /// </summary>
        [JsonIgnore]
        public int? Limit { get; set; }
    }
}
