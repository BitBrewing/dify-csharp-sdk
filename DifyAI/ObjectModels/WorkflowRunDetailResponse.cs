using System;
using System.Text.Json.Serialization;
using DifyAI.Json;

namespace DifyAI.ObjectModels;


/// <summary>
/// 工作流运行详情响应模型
/// </summary>
public class WorkflowRunDetailResponse : ResponseBase
{
    /// <summary>
    /// 工作流执行ID
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    /// <summary>
    /// 相关工作流ID
    /// </summary>
    [JsonPropertyName("workflow_id")]
    public string WorkflowId { get; set; }
    
    /// <summary>
    /// 执行状态（running, succeeded, failed, stopped）
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
    
    /// <summary>
    /// 输入内容
    /// </summary>
    [JsonPropertyName("inputs")]
    public string Inputs { get; set; }
    
    /// <summary>
    /// 输出内容
    /// </summary>
    [JsonPropertyName("outputs")]
    public string? Outputs { get; set; }
    
    /// <summary>
    /// 错误原因
    /// </summary>
    [JsonPropertyName("error")]
    public string Error { get; set; }
    
    /// <summary>
    /// 任务总步骤数
    /// </summary>
    [JsonPropertyName("total_steps")]
    public int TotalSteps { get; set; }
    
    /// <summary>
    /// 使用的总token数
    /// </summary>
    [JsonPropertyName("total_tokens")]
    public int TotalTokens { get; set; }
    
    /// <summary>
    /// 开始时间（时间戳）
    /// </summary>
    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(UnixTimestampConverter))]
    public DateTimeOffset CreatedAt { get; set; }
    
    /// <summary>
    /// 结束时间（时间戳）
    /// </summary>
    [JsonPropertyName("finished_at")]
    [JsonConverter(typeof(UnixTimestampConverter))]
    public DateTimeOffset FinishedAt { get; set; }
    
    /// <summary>
    /// 总耗时（秒）
    /// </summary>
    [JsonPropertyName("elapsed_time")]
    public float ElapsedTime { get; set; }
}