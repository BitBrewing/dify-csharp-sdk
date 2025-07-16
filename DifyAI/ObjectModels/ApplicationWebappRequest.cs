using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

/// <summary>
/// 用于获取应用的 WebApp 设置请求
/// </summary>
public class ApplicationWebappRequest : RequestBase
{
    /// <summary>
    /// 用户标识，用于定义终端用户的身份，方便检索、统计。 由开发者定义规则，需保证用户标识在应用内唯一。
    /// </summary>
    [JsonPropertyName("user")]
    public string User { get; set; }
}