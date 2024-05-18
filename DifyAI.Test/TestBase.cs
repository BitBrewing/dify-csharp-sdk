using System;
using DifyAI.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace DifyAI.Test
{
	public class TestBase
	{
		protected readonly IDifyAIService _difyAIService;

        public TestBase()
        {
            var services = new ServiceCollection();

            services
                .AddDifyAIService(x =>
                {
                    x.BaseDomain = "http://10.13.60.91/v1";
                    x.ApiKey = "app-3ppSoe6ynEvBgTpugCyenxr6";
                });

            var app = services.BuildServiceProvider();
            _difyAIService = app.GetRequiredService<IDifyAIService>();
        }
	}
}

