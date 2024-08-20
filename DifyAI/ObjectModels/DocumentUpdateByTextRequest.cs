using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentUpdateByTextRequest : RequestBase
    {
        public const string IndexingTechniqueHighQuality = "high_quality";
        public const string IndexingTechniqueEconomy = "economy";

        /// <summary>
        ///     Dataset Id
        /// </summary>
        [JsonIgnore]
        public string DatasetId { get; set; }

        /// <summary>
        ///     Dataset Id
        /// </summary>
        [JsonIgnore]
        public string DocumentId { get; set; }

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

        /// <summary>
        ///     Index mode
        ///     high_quality : embedding using embedding model, built as vector database index
        ///     economy : Build using inverted index of Keyword Table Index
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("indexing_technique")]
        public string IndexingTechnique { get; set; }

        /// <summary>
        ///     Preprocessing rules
        /// </summary>
        [JsonPropertyName("process_rule")]
        public DatasetProcessRule ProcessRule { get; set; }
    }
}
