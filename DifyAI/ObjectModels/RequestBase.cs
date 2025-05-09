using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public abstract class RequestBase: IRequest
    {
        /// <summary>
        /// API 密钥，默认为注册时的 options.DefaultApiKey
        /// </summary>
        [JsonIgnore]
        public string ApiKey { get; set; }
        /// <summary>
        /// API 地址，默认为注册时的 options.BaseDomain
        /// </summary>
        [JsonIgnore]
        public string? BaseDomain { get; set; } = null;
    }

    public class EmptyRequest : RequestBase
    {
    }
}
