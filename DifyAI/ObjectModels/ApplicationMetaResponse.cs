using System.Text.Json;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class ApplicationMetaResponse : ResponseBase
    {
        [JsonPropertyName("tool_icons")]
        public JsonDocument ToolIcons { get; set; }
    }
}