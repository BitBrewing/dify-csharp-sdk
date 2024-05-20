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
                    x.BaseDomain = "http://10.205.4.101:15000/v1";
                    x.DefaultApiKey = "app-vKpvZXTPehLr955rijCvyLAq";
                });

            var app = services.BuildServiceProvider();
            _difyAIService = app.GetRequiredService<IDifyAIService>();
        }
	}
}

