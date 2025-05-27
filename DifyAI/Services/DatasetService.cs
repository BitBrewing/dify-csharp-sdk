using DifyAI.Interfaces;
using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace DifyAI.Services
{
    partial class DifyAIService : IDatasetService
    {
        public async Task<DatasetResponse> CreateDatasetAsync(DatasetCreateRequest request, CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                return await _httpClient.PostAsAsync<DatasetResponse>($"datasets", request, cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task<DatasetListResponse> GetDatasetsAsync(DatasetListRequest request, CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                return await _httpClient.GetAsAsync<DatasetListResponse>($"datasets?page={request.Page}&limit={request.Limit}", new EmptyRequest(), cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task DeleteDatasetAsync(DatasetDeleteRequest request, CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                await _httpClient.DeleteAsync($"datasets/{request.DatasetId}", request, cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task<DocumentResponse> CreateDocumentByTextAsync(DocumentUpsetByTextRequest request, CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                return await _httpClient.PostAsAsync<DocumentResponse>($"datasets/{request.DatasetId}/document/create_by_text", request, cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task<DocumentResponse> UpdateDocumentByTextAsync(DocumentUpdateByTextRequest request, CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                return await _httpClient.PostAsAsync<DocumentResponse>($"datasets/{request.DatasetId}/documents/{request.DocumentId}/update_by_text", request, cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task<DocumentResponse> CreateDocumentByFileAsync(DocumentUpsetByFileRequest request, CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                return await _httpClient.UploadDocumentAsync<DocumentResponse>($"datasets/{request.DatasetId}/document/create_by_file", request, cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task<DocumentResponse> UpdateDocumentByFileAsync(DocumentUpdateByFileRequest request, CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                return await _httpClient.UploadDocumentAsync<DocumentResponse>($"datasets/{request.DatasetId}/documents/{request.DocumentId}/update_by_file", request, cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task DeleteDocumentAsync(DocumentDeleteRequest request, CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                await _httpClient.DeleteAsync($"datasets/{request.DatasetId}/documents/{request.DocumentId}", request, cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task<DocumentListResponse> GetDocumentsAsync(DocumentListRequest request, CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                return await _httpClient.GetAsAsync<DocumentListResponse>($"datasets/{request.DatasetId}/documents?keyword={HttpUtility.UrlEncode(request.Keyword)}&page={request.Page}&limit={request.Limit}", new EmptyRequest(), cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task<DocumentEmbeddingResponse> GetDocumentsEmbeddingAsync(DocumentEmbeddingRequest request, CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                return await _httpClient.GetAsAsync<DocumentEmbeddingResponse>($"datasets/{request.DatasetId}/documents/{request.Batch}/indexing-status", new EmptyRequest(), cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }


        public async Task<DocumentSegmentResponse> AddDocumentSegmentsAsync(DocumentSegmentAddRequest request, CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                return await _httpClient.PostAsAsync<DocumentSegmentResponse>($"datasets/{request.DatasetId}/documents/{request.DocumentId}/segments", request, cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task<DocumentSegmentUpdateResponse> UpdateDocumentSegmentAsync(DocumentSegmentUpdateRequest request, CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                return await _httpClient.PostAsAsync<DocumentSegmentUpdateResponse>($"datasets/{request.DatasetId}/documents/{request.DocumentId}/segments/{request.SegmentId}", request, cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task DeleteDocumentSegmentAsync(DocumentSegmentDeleteRequest request, CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                await _httpClient.DeleteAsync($"datasets/{request.DatasetId}/documents/{request.DocumentId}/segments/{request.SegmentId}", request, cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task<DocumentSegmentResponse> GetDocumentSegmentsAsync(DocumentSegmentListRequest request, CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                return await _httpClient.GetAsAsync<DocumentSegmentResponse>($"datasets/{request.DatasetId}/documents/{request.DocumentId}/segments?keyword={HttpUtility.UrlEncode(request.Keyword)}&status={request.Status}", new EmptyRequest(), cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task<DatasetRetrieveResponse> RetrieveDatasetAsync(DatasetRetrieveRequest request,
            CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                return await _httpClient.PostAsAsync<DatasetRetrieveResponse>($"datasets/{request.DatasetId}/retrieve", request, cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task<DatasetGetResponse> GetDatasetAsync(DatasetGetRequest request,
            CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                return await _httpClient.GetAsAsync<DatasetGetResponse>($"datasets/{request.DatasetId}", request, cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task<DatasetUpdateResponse> UpdateDatasetAsync(DatasetUpdateRequest request,
            CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                return await _httpClient.PatchAsAsync<DatasetUpdateResponse>($"datasets/{request.DatasetId}", request, cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }

        public async Task<DatasetGetTextEmbeddingModelsResponse> GetTextEmbeddingModelsAsync(DatasetGetTextEmbeddingModelsRequest request,
            CancellationToken cancellationToken = default)
        {
            UseDatasetApiKey();
            try
            {
                return await _httpClient.GetAsAsync<DatasetGetTextEmbeddingModelsResponse>("workspaces/current/models/model-types/text-embedding", request, cancellationToken);
            }
            finally
            {
                UseDefaultApiKey();
            }
        }
    }
}
