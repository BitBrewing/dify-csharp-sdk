using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DatasetDeleteRequest: RequestBase
    {
        /// <summary>
        /// Dataset ID
        /// </summary>
        [JsonIgnore]
        public string DatasetId { get; set; }
    }
}
