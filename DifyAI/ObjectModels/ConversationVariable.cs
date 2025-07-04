using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using DifyAI.Json;

namespace DifyAI.ObjectModels;

public class ConversationVariable
{
    /// <summary>
    /// 變量 ID。
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// 變量名称
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    /// <summary>
    /// 變量類型
    /// </summary>
    [JsonPropertyName("value_type")]
    public string ValueType { get; set; }
    
    /// <summary>
    /// 變量值
    /// </summary>
    [JsonPropertyName("value")]
    public string Value { get; set; }
    
    /// <summary>
    /// 创建时间。
    /// </summary>
    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(UnixTimestampConverter))]
    public DateTimeOffset CreatedAt { get; set; }
    
    /// <summary>
    /// 更變时间。
    /// </summary>
    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(UnixTimestampConverter))]
    public DateTimeOffset UpdatedAt { get; set; }
}