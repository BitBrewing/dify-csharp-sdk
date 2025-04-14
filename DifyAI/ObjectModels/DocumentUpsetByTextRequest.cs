using System.Text.Json;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentUpsetByTextRequest : DocumentUpsetRequestBase
    {
        public const string IndexingTechniqueHighQuality = "high_quality";
        public const string IndexingTechniqueEconomy = "economy";

        /// <summary>
        ///     Dataset Id
        /// </summary>
        [JsonIgnore]
        public string DatasetId { get; set; }

        /// <summary>
        ///     Document name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     text
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
