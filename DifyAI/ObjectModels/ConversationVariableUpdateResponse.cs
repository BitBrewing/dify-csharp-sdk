using System;
using System.Text.Json.Serialization;
using DifyAI.Json;

namespace DifyAI.ObjectModels;

public class ConversationVariableUpdateResponse : ResponseBase
{
    /// <summary>
    /// 变量 ID
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// 变量名称
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// 变量类型 (string, number, object, etc.)
    /// </summary>
    [JsonPropertyName("value_type")]
    public string ValueType { get; set; }

    /// <summary>
    /// 更新后的变量值
    /// </summary>
    [JsonPropertyName("value")]
    public object Value { get; set; }

    /// <summary>
    /// 变量描述
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// 创建时间戳
    /// </summary>
    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(UnixTimestampConverter))]
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// 最后更新时间戳
    /// </summary>
    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(UnixTimestampConverter))]
    public DateTimeOffset UpdatedAt { get; set; }
}