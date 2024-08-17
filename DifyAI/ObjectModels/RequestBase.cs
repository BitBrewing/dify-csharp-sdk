using System.Text.Json.Serialization;

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

    public class EmptyRequest : RequestBase
    {
    }
}
