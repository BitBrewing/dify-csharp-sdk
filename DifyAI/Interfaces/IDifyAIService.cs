using System;
using System.Collections.Generic;
using System.Text;

namespace DifyAI.Interfaces
{
    public interface IDifyAIService
    {
        IChatMessagesService ChatMessages { get; }
        IMessagesService Messages { get; }
        IFilesService Files { get; }
    }
}
