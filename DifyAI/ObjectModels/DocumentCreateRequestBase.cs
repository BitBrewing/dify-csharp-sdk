using System.Text.Json;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels;

public abstract class DocumentCreateRequestBase: RequestBase
{
    /// <summary>
    ///     Index mode
    ///     high_quality : embedding using embedding model, built as vector database index
    ///     economy : Build using inverted index of Keyword Table Index
    /// </summary>
    /// <returns></returns>
    [JsonPropertyName("indexing_technique")]
    public string IndexingTechnique { get; set; }

    /// <summary>
    ///     Preprocessing rules
    /// </summary>
    [JsonPropertyName("process_rule")]
    public DatasetProcessRule ProcessRule { get; set; }
    
    /// <summary>
        /// 文档类型（选填）
        /// <list type="bullet">
        /// <item>book 图书 Book</item>
        /// <item>web_page 网页 Web page</item>
        /// <item>paper 学术论文/文章 Academic paper/article</item>
        /// <item>social_media_post 社交媒体帖子 Social media post</item>
        /// <item>wikipedia_entry 维基百科条目 Wikipedia entry</item>
        /// <item>personal_document 个人文档 Personal document</item>
        /// <item>business_document 商业文档 Business document</item>
        /// <item>im_chat_log 即时通讯记录 Chat log</item>
        /// <item>synced_from_notion Notion同步文档 Notion document</item>
        /// <item>synced_from_github GitHub同步文档 GitHub document</item>
        /// <item>others 其他文档类型 Other document types</item>
        /// </list>
        /// </summary>
        [JsonPropertyName("doc_type")]
        public string DocType { get; set; }
        
        /// <summary>
        /// 索引内容的形式
        /// <list type="bullet">
        /// <item>text_model text 文档直接 embedding，经济模式默认为该模式</item>
        /// <item>hierarchical_model parent-child 模式</item>
        /// <item>qa_model Q&amp;A 模式：为分片文档生成 Q&amp;A 对，然后对问题进行 embedding</item>
        /// </list>
        /// </summary>
        [JsonPropertyName("doc_form")]
        public string DocForm { get; set; }
        
        /// <summary>
        /// 在 Q&amp;A 模式下，指定文档的语言，例如：English、Chinese
        /// </summary>
        [JsonPropertyName("doc_language")]
        public string DocLanguage { get; set; }
        
        /// <summary>
        /// 文档元数据（如提供文档类型则必填）。字段因文档类型而异
        /// </summary>
        [JsonPropertyName("doc_metadata")]
        public JsonDocument DocMetadata { get; set; }

        /// <summary>
        /// 检索模式
        /// </summary>
        [JsonPropertyName("retrieval_model")]
        public DatasetRetrievalModel RetrievalModel { get; set; }
        
        /// <summary>
        /// Embedding 模型名称
        /// </summary>
        [JsonPropertyName("embedding_model")]
        public string EmbeddingModel { get; set; }
        
        /// <summary>
        /// Embedding 模型供应商
        /// </summary>
        [JsonPropertyName("embedding_model_provider")]
        public string EmbeddingModelProvider { get; set; }
}