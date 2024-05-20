# Dify CSharp SDK

## 安装
```
Install-Package DifyAI
```

## 注册
```csharp
services
    .AddDifyAI(x =>
    {
        x.BaseDomain = "http://127.0.0.1/v1";
        x.DefaultApiKey = "app-xxxxxxxxxxxxxxxx";
    });
```

## 使用
```csharp
private readonly IDifyAIService _difyAIService;
```

### 聊天助手、Agent 应用消息
```csharp
// 阻塞模式
var rsp = await _difyAIService.ChatMessages.ChatAsync(req);

// 流式模式
await foreach (var rsp in _difyAIService.ChatMessages.ChatStreamAsync(req))
{
}

// 停止响应
await _difyAIService.ChatMessages.StopChatAsync(req);
```

### 工作流应用消息
```csharp
// 阻塞模式
var rsp = await _difyAIService.Workflows.WorkflowAsync(req);

// 流式模式
await foreach (var rsp in _difyAIService.Workflows.WorkflowStreamAsync(req))
{
}

// 停止响应
await _difyAIService.Workflows.StopWorkflowAsync(req);
```

### 文本生成应用消息
```csharp
// 阻塞模式
var rsp = await _difyAIService.CompletionMessages.CompletionAsync(req);

// 流式模式
await foreach (var rsp in _difyAIService.CompletionMessages.CompletionStreamAsync(req))
{
}

// 停止响应
await _difyAIService.CompletionMessages.StopCompletionAsync(req);
```

### 文件
```csharp
// 上传文件
var rsp = await _difyAIService.Files.UploadAsync(req);
```

### 音频
```csharp
// 语音转文字
var rsp = await _difyAIService.Audios.AudioToTextAsync(req);

// 文字转语音
var rsp = await _difyAIService.Audios.TextToAudioAsync(req);
```