## 安装
```
Install-Package DifyAI
```

## 注册
```csharp
services
    .AddDifyAI(x =>
    {
        x.BaseDomain = "xxx";
        x.ApiKey = "xxx";
    });
```

## 使用
```csharp
private readonly IDifyAIService _difyAIService;

// 发送对话消息
var req = new CompletionRequest
{
    Query = "xxx",
    User = "xxx",
};

// 阻塞模式
var rsp = await _difyAIService.ChatMessages.CompletionAsync
(req);

// 流式模式
await foreach (var rsp in _difyAIService.ChatMessages.ChunkCompletionAsync(req))
{
    if (rsp is ChunkCompletionMessageResponse rspMessage)
    {
                    
    }
    else if (rsp is ChunkCompletionErrorResponse rspError)
    {

    }
}
```