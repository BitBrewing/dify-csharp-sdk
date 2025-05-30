using DifyAI.ObjectModels;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI.Interfaces
{
    public interface IDatasetService
    {
        /// <summary>
        /// Create document by text
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentResponse> CreateDocumentByTextAsync(DocumentUpsetByTextRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update document by text
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentResponse> UpdateDocumentByTextAsync(DocumentUpdateByTextRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create empty dataset
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DatasetResponse> CreateDatasetAsync(DatasetCreateRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get datasets
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DatasetListResponse> GetDatasetsAsync(DatasetListRequest request, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Delete a dataset
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteDatasetAsync(DatasetDeleteRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve a dataset
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DatasetRetrieveResponse> RetrieveDatasetAsync(DatasetRetrieveRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create document by file
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentResponse> CreateDocumentByFileAsync(DocumentUpsetByFileRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update document by file
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentResponse> UpdateDocumentByFileAsync(DocumentUpdateByFileRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete document
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteDocumentAsync(DocumentDeleteRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get list of documents from a dataset
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentListResponse> GetDocumentsAsync(DocumentListRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get document embedding status (progress)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentEmbeddingResponse> GetDocumentsEmbeddingAsync(DocumentEmbeddingRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add document segments
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentSegmentResponse> AddDocumentSegmentsAsync(DocumentSegmentAddRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update document segment
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentSegmentUpdateResponse> UpdateDocumentSegmentAsync(DocumentSegmentUpdateRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete document segment
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteDocumentSegmentAsync(DocumentSegmentDeleteRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get list of document segments from a document
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentSegmentResponse> GetDocumentSegmentsAsync(DocumentSegmentListRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 查看知识库详情
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DatasetGetResponse> GetDatasetAsync(DatasetGetRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 修改知识库详情
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DatasetUpdateResponse> UpdateDatasetAsync(DatasetUpdateRequest request, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// 获取嵌入模型列表
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DatasetGetTextEmbeddingModelsResponse> GetTextEmbeddingModelsAsync(DatasetGetTextEmbeddingModelsRequest request, CancellationToken cancellationToken = default);
    }
}