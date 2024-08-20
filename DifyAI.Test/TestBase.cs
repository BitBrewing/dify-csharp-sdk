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
                    x.BaseDomain = "http://localhost/v1";
                    x.DefaultApiKey = "app-i8zgSq0L0Pk6ixmvbJCHFGcU";
                    x.DatasetApiKey = "dataset-rg6t21M26kP3F4ron3QtEVQT";
                });

            var app = services.BuildServiceProvider();
            _difyAIService = app.GetRequiredService<IDifyAIService>();
        }
	}
}

