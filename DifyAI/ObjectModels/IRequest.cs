using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    internal interface IRequest
    {
        string ApiKey { get; }
        string BaseDomain { get; }
    }
}
