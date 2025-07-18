using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

/// <summary>
/// 应用的 WebApp 设置响应
/// </summary>
public class ApplicationWebappResponse : ResponseBase
{
    /// <summary>
    /// WebApp 名称
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// 聊天颜色主题，hex 格式
    /// </summary>
    [JsonPropertyName("chat_color_theme")]
    public string ChatColorTheme { get; set; }

    /// <summary>
    /// 聊天颜色主题是否反转
    /// </summary>
    [JsonPropertyName("chat_color_theme_inverted")]
    public bool ChatColorThemeInverted { get; set; }

    /// <summary>
    /// 图标类型，emoji-表情，image-图片
    /// </summary>
    [JsonPropertyName("icon_type")]
    public string IconType { get; set; }

    /// <summary>
    /// 图标，如果是 emoji 类型，则是 emoji 表情符号，如果是 image 类型，则是图片 URL
    /// </summary>
    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    /// <summary>
    /// hex 格式的背景色
    /// </summary>
    [JsonPropertyName("icon_background")]
    public string IconBackground { get; set; }

    /// <summary>
    /// 图标 URL
    /// </summary>
    [JsonPropertyName("icon_url")]
    public string IconUrl { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// 版权信息
    /// </summary>
    [JsonPropertyName("copyright")]
    public string Copyright { get; set; }

    /// <summary>
    /// 隐私政策链接
    /// </summary>
    [JsonPropertyName("privacy_policy")]
    public string PrivacyPolicy { get; set; }

    /// <summary>
    /// 自定义免责声明
    /// </summary>
    [JsonPropertyName("custom_disclaimer")]
    public string CustomDisclaimer { get; set; }

    /// <summary>
    /// 默认语言
    /// </summary>
    [JsonPropertyName("default_language")]
    public string DefaultLanguage { get; set; }

    /// <summary>
    /// 是否显示工作流详情
    /// </summary>
    [JsonPropertyName("show_workflow_steps")]
    public bool ShowWorkflowSteps { get; set; }

    /// <summary>
    /// 是否使用 WebApp 图标替换聊天中的 🤖
    /// </summary>
    [JsonPropertyName("use_icon_as_answer_icon")]
    public bool UseIconAsAnswerIcon { get; set; }
}