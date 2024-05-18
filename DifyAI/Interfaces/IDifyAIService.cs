using System;
using System.Collections.Generic;
using System.Text;

namespace DifyAI.Interfaces
{
    public interface IDifyAIService
    {
        /// <summary>
        /// 聊天助手、Agent 应用消息
        /// </summary>
        IChatMessagesService ChatMessages { get; }

        /// <summary>
        /// 消息
        /// </summary>
        IMessagesService Messages { get; }

        /// <summary>
        /// 文件
        /// </summary>
        IFilesService Files { get; }

        /// <summary>
        /// 工作流应用消息
        /// </summary>
        IWorkflowsService Workflows { get; }

        /// <summary>
        /// 文本生成应用消息
        /// </summary>
        ICompletionMessagesService CompletionMessages { get; }
    }
}
