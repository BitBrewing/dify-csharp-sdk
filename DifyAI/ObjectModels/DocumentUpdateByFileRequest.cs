using System.IO;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class DocumentUpdateByFileRequest : DocumentUpsetRequestBase, IUploadRequest
    {
        /// <summary>
        ///     Dataset Id
        /// </summary>
        [JsonIgnore]
        public string DatasetId { get; set; }

        /// <summary>
        ///     Document ID
        /// </summary>
        [JsonPropertyName("document_id")]
        public string DocumentId { get; set; }

        /// <summary>
        /// 要上传的文件
        /// </summary>
        [JsonIgnore]
        public string File { get; set; }

        /// <summary>
        /// 要上传的文件流
        /// </summary>
        [JsonIgnore]
        public Stream FileStream { get; }

        /// <summary>
        ///     Source document ID (optional)
        ///     Used to re-upload the document or modify the document cleaning and segmentation configuration.The missing information is copied from the source document
        ///     The source document cannot be an archived document
        ///     When original_document_id is passed in, the update operation is performed on behalf of the document.process_rule is a fillable item.If not filled in, the segmentation method of the source document will be used by default
        ///     When original_document_id is not passed in, the new operation is performed on behalf of the document, and process_rule is required
        /// </summary>
        [JsonPropertyName("original_document_id")]
        public string OriginalDocumentId { get; set; }
    }
}
