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
await _difyAIService.Files.UploadAsync(req);
```

### 音频
```csharp
// 语音转文字
await _difyAIService.Audios.AudioToTextAsync(req);

// 文字转语音
await _difyAIService.Audios.TextToAudioAsync(req);
```

### 会话
```csharp
// 获取会话列表
await _difyAIService.Conversations.ListAsync(req);

// 会话重命名
await _difyAIService.Conversations.RenameAsync(req);

// 删除会话
await _difyAIService.Conversations.DeleteAsync(req);
```
### 消息
```csharp
// 获取会话历史消息
await _difyAIService.Messages.HistoryAsync(req);

// 消息反馈（点赞）
await _difyAIService.Messages.FeedbackAsync(req);

// 获取下一轮建议问题列表
await _difyAIService.Messages.SuggestedAsync(req);
```