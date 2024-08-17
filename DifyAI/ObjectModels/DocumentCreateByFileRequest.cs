﻿using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentCreateByFileRequest : RequestBase, IUploadRequest
    {
        /// <summary>
        ///     Dataset Id
        /// </summary>
        [JsonIgnore]
        public string DatasetId { get; set; }

        /// <summary>
        /// 要上传的文件
        /// </summary>
        [JsonIgnore]
        public string File { get; set; }

        /// <summary>
        ///     Source document ID (optional)
        ///     Used to re-upload the document or modify the document cleaning and segmentation configuration.The missing information is copied from the source document
        ///     The source document cannot be an archived document
        ///     When original_document_id is passed in, the update operation is performed on behalf of the document.process_rule is a fillable item.If not filled in, the segmentation method of the source document will be used by default
        ///     When original_document_id is not passed in, the new operation is performed on behalf of the document, and process_rule is required
        /// </summary>
        [JsonPropertyName("original_document_id")]
        public string OriginalDocumentId { get; set; }

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
    }
}
