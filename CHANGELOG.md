# 更新历史

## 3.7.3
- 修复`Datasets.UpdateDatasetAsync`会出现`The JSON value could not be converted to System.Boolean`错误的问题 [#16](https://github.com/BitBrewing/dify-csharp-sdk/issues/16#issuecomment-2909082934)

## 3.7.2
- 修复 3.7.0 新增的三个接口报404的问题 [#16](https://github.com/BitBrewing/dify-csharp-sdk/issues/16#issuecomment-2892806931)

## 3.7.0
- 新增：查看知识库详情`Datasets.GetDatasetAsync` [#16](https://github.com/BitBrewing/dify-csharp-sdk/issues/16#issuecomment-2870547089)
- 新增：修改知识库详情`Datasets.UpdateDatasetAsync` [#16](https://github.com/BitBrewing/dify-csharp-sdk/issues/16#issuecomment-2870547089)
- 新增：获取嵌入模型列表`Datasets.GetTextEmbeddingModelsAsync` [#16](https://github.com/BitBrewing/dify-csharp-sdk/issues/16#issuecomment-2870547089)

## 3.6.0
- 新增：请求参数添加`BaseDomain`，以解决多个Dify服务器的情况下，一个BaseDomain不够的问题（贡献者 [@ZeroZ-lab](https://github.com/Rendtime)，PR [#18](https://github.com/BitBrewing/dify-csharp-sdk/pull/18)）
- 新增：响应内容增加`RawJson`原始Json字符串（贡献者 [@ZeroZ-lab](https://github.com/Rendtime)，PR [#18](https://github.com/BitBrewing/dify-csharp-sdk/pull/18)）

## 3.5.0
- 新增：获取应用基本信息接口`Applications.InfoAsync` [#16](https://github.com/BitBrewing/dify-csharp-sdk/issues/16)

## 3.4.0
- 将 `CompletionMessages.CompletionAsync/CompletionStreamAsync`参数由`ChatCompletionRequest`改为`CompletionRequest` [#14](https://github.com/BitBrewing/dify-csharp-sdk/issues/14)

## 3.3.0

- 修复: 停止工作流的请求url错误 [#11](https://github.com/BitBrewing/dify-csharp-sdk/issues/11)
- 修复: 添加缺少的创建知识库的请求参数 [#9](https://github.com/BitBrewing/dify-csharp-sdk/issues/9#issuecomment-2795688431)
- 修复: 添加缺少的通过文件更新文档的请求参数 [#9](https://github.com/BitBrewing/dify-csharp-sdk/issues/9#issuecomment-2795688431)
- 新增: 检索知识库接口（`DataSets.RetrieveDatasetAsync`） [#9](https://github.com/BitBrewing/dify-csharp-sdk/issues/9#issuecomment-2795688431)
- 修复: 在`ProcessRule`这个类里，缺失了父分段的召回模式、子分段规则等参数 [#9](https://github.com/BitBrewing/dify-csharp-sdk/issues/9#issuecomment-2795688431)