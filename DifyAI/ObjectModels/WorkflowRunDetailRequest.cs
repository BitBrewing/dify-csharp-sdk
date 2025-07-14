using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public class WorkflowRunDetailRequest : RequestBase
{
  /// <summary>
  /// Workflow ID
  /// </summary>
  [JsonIgnore]
  public string WorkflowId { get; set; }
}