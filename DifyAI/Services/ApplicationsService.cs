using System.Threading;
using System.Threading.Tasks;
using DifyAI.Interfaces;
using DifyAI.ObjectModels;

namespace DifyAI.Services
{
    partial class DifyAIService : IApplicationsService
    {
        public async Task<ApplicationMetaResponse> MetaAsync(ApplicationMetaRequest request, CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetAsAsync<ApplicationMetaResponse>("meta", request, cancellationToken);
        }

        public async Task<ApplicationParametersResponse> ParametersAsync(ApplicationParametersRequest request, CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetAsAsync<ApplicationParametersResponse>("parameters", request, cancellationToken);
        }

        public async Task<ApplicationInfoResponse> InfoAsync(ApplicationInfoRequest request, CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetAsAsync<ApplicationInfoResponse>("info", request, cancellationToken);
        }
    }
}