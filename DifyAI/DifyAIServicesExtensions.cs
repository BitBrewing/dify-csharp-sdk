using DifyAI.Interfaces;
using DifyAI.Internals;
using DifyAI.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DifyAIServicesExtensions
    {
        public static IHttpClientBuilder AddDifyAIService(this IServiceCollection services)
        {
            return services.AddDifyAIService(_ => { });
        }

        public static IHttpClientBuilder AddDifyAIService(this IServiceCollection services, Action<DifyAIOptions> configure)
        {
            services.Configure(configure);

            return services.AddHttpClient<IDifyAIService, DifyAIService>()
                .ConfigureHttpClient((provider, httpClient) =>
                {
                    var options = provider.GetService<IOptions<DifyAIOptions>>().Value;

                    var host = new UriBuilder(options.BaseDomain);
                    if (!host.Path.EndsWith("/"))
                    {
                        host.Path += "/";
                    }

                    httpClient.BaseAddress = host.Uri;
                    httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"Bearer {options.ApiKey}");
                });
        }
    }
}
