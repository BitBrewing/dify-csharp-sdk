using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DatasetListRequest
    {
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
