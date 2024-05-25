using System.Threading;
using System.Threading.Tasks;
using DifyAI.ObjectModels;

namespace DifyAI.Interfaces
{
    public interface IApplicationsService
    {
        /// <summary>
        /// 获取应用配置信息
        /// </summary>
        /// <remarks>用于进入页面一开始，获取功能开关、输入参数名称、类型及默认值等使用。</remarks>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ApplicationParametersResponse> ParametersAsync(ApplicationParametersRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取应用Meta信息
        /// </summary>
        /// <remarks>用于获取工具icon</remarks>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ApplicationMetaResponse> MetaAsync(ApplicationMetaRequest request, CancellationToken cancellationToken = default);
    }
}