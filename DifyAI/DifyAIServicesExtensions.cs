﻿using DifyAI;
using DifyAI.Interfaces;
using DifyAI.Services;
using DifyAI.Options;
using Microsoft.Extensions.Options;
using System;

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
                    httpClient.AddAuthorization(options.DefaultApiKey);
                })
                // Pass the configured DifyAIOptions to the DifyAIService
                .AddTypedClient((httpClient, provider) =>
                {
                    var options = provider.GetService<IOptions<DifyAIOptions>>();
                    return new DifyAIService(httpClient, options);
                });
        }
    }
}
