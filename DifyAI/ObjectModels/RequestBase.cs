using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public abstract class RequestBase: IRequest
    {
        /// <summary>
        /// API 密钥，默认为注册时的 options.ApiKey
        /// </summary>
        [JsonIgnore]
        public string ApiKey { get; set; }
    }
}
