using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class ResponseBase
{
    /// <summary>
    /// 原始JSON字符串
    /// </summary>
    [JsonIgnore]
    public string RawJson { get; set; }
}