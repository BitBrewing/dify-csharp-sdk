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

var req = new CreateCompletionRequest
{
    Query = "xxx",
    User = "xxx",
};
var rsp = await _difyAIService.ChatMessages.CreateCompletionAsync(req);
```