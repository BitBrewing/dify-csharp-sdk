using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetSubchunkSegmentation
{
    /// <summary>
    /// 分段标识符，目前仅允许设置一个分隔符。默认为 ***
    /// </summary>
    [JsonPropertyName("separator")]
    public string Separator { get; set; } = "***";

    /// <summary>
    /// 最大长度 (token) 需要校验小于父级的长度
    /// </summary>
    [JsonPropertyName("max_tokens")]
    public int? MaxTokens { get; set; }

    /// <summary>
    /// 分段重叠指的是在对数据进行分段时，段与段之间存在一定的重叠部分（选填）
    /// </summary>
    [JsonPropertyName("chunk_overlap")]
    public int? ChunkOverlap { get; set; }
}