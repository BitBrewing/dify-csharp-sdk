using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DatasetCreateRequest : RequestBase
    {
        /// <summary>
        /// Name of the dataset
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
