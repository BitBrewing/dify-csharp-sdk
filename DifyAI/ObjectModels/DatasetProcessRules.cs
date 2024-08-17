using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DatasetProcessRule
    {
        public const string ModeAutomatic = "automatic";
        public const string ModeCustom = "custom";

        /// <summary>
        ///     Document Cleaning Mode, segmentation mode, automatic / custom
        /// </summary>
        [JsonPropertyName("mode")]
        public string Mode { get; set; } = ModeAutomatic;


        /// <summary>
        ///     Custom rules (in automatic mode, this field is empty)
        /// </summary>
        [JsonPropertyName("rules")]
        public DatasetProcessRuleRuleItem Rules { get; set; }
    }

    public class DatasetProcessRuleRuleItem
    {
        /// <summary>
        /// Pre-processing rules
        /// </summary>
        [JsonPropertyName("pre_processing_rules")]
        public List<DatasetProcessRulePreProcessingRules> PreProcessingRules { get; set; }

        /// <summary>
        ///    Segmentation rules
        /// </summary>
        [JsonPropertyName("segmentation")]
        public DatasetProcessRuleSegmentation Segmentation { get; set; }
    }

    public class DatasetProcessRuleSegmentation
    {
        /// <summary>
        ///     Custom segment identifier, currently only allows one delimiter to be set. Default is \n
        /// </summary>
        [JsonPropertyName("separator")]
        public string Separator { get; set; } = "\n";

        /// <summary>
        ///     Maximum length (token) defaults to 1000
        /// </summary>
        [JsonPropertyName("max_tokens")]
        public int? MaxTokens { get; set; }
    }

    public class DatasetProcessRulePreProcessingRules
    {
        public const string IdRemoveExtraSpaces = "remove_extra_spaces";
        public const string IdRemoveUrlsEmails = "remove_urls_emails";

        /// <summary>
        ///     Unique identifier for the preprocessing rule
        ///     - remove_extra_spaces Replace consecutive spaces, newlines, tabs
        ///     - remove_urls_emails Delete URL, email address
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }


        /// <summary>
        ///     Whether to select this rule or not.
        ///     If no document ID is passed in, it represents the default value.
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; }
    }
}
