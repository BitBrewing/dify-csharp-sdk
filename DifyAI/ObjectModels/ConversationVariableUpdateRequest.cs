using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class ConversationVariableUpdateRequest : RequestBase
{
    /// <summary>
    /// 会话ID
    /// </summary>
    [JsonIgnore]
    public string ConversationId { get; set; }

    /// <summary>
    /// 变量ID
    /// </summary>
    [JsonIgnore]
    public string VariableId { get; set; }

    /// <summary>
    /// 用户标识，用于定义终端用户的身份，方便检索、统计。 由开发者定义规则，需保证用户标识在应用内唯一。
    /// </summary>
    [JsonPropertyName("user")]
    public string User { get; set; }

    /// <summary>
    /// 变量值 (可以是 string, number, object 等)
    /// </summary>
    [JsonPropertyName("value")]
    public object Value { get; set; }
}