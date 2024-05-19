using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DifyAI.Interfaces;
using DifyAI.ObjectModels;

namespace DifyAI.Services
{
    internal partial class DifyAIService : IDifyAIService
    {
        private readonly HttpClient _httpClient;

        public DifyAIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IChatMessagesService ChatMessages => this;
        public IMessagesService Messages => this;
        public IFilesService Files => this;
        public IWorkflowsService Workflows => this;
        public ICompletionMessagesService CompletionMessages => this;
        public IAudiosService Audios => this;
    }
}
