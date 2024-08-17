using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DifyAI.Interfaces;
using DifyAI.ObjectModels;
using DifyAI.Options;
using Microsoft.Extensions.Options;

namespace DifyAI.Services
{
    internal partial class DifyAIService : IDifyAIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _datasetApiKey;
        private readonly string _defaultApiKey;

        public DifyAIService(HttpClient httpClient, IOptions<DifyAIOptions> options)
        {
            _httpClient = httpClient;
            _defaultApiKey = options.Value.DefaultApiKey;
            _datasetApiKey = options.Value.DatasetApiKey;
        }

        private void UseDatasetApiKey()
        {
            this._httpClient.AddAuthorization(this._datasetApiKey);
        }

        private void UseDefaultApiKey()
        {
            this._httpClient.AddAuthorization(this._defaultApiKey);
        }

        public IConversationsService Conversations => this;
        public IChatMessagesService ChatMessages => this;
        public IMessagesService Messages => this;
        public IFilesService Files => this;
        public IWorkflowsService Workflows => this;
        public ICompletionMessagesService CompletionMessages => this;
        public IAudiosService Audios => this;
        public IApplicationsService Applications => this;
        public IDatasetService Datasets => this;
    }
}
