using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class DatasetRetrieveResponse : ResponseBase
{
    [JsonPropertyName("query")]
    public DatasetQuery Query { get; set; }
    
    [JsonPropertyName("records")]
    public IReadOnlyList<DatasetRecord> Records { get; set; }
}