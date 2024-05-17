using DifyAI.Interfaces;
using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI.Internals
{
    partial class DifyAIService: IWorkflowsService
    {
        public async Task RunCompletionAsync(CreateWorkflowCompletionRequest reqeust, CancellationToken cancellationToken = default)
        {

        }

        public async Task RunCompletionStreamAsync(CreateWorkflowCompletionRequest reqeust, CancellationToken cancellationToken = default)
        {

        }

        public async Task StopAsync()
        {

        }
    }
}
