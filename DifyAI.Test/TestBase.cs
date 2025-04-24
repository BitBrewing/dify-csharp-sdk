using System;
using DifyAI.Interfaces;
using DifyAI.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DifyAI.Test
{
	public class TestBase
	{
		protected readonly IDifyAIService _difyAIService;

        public TestBase()
        {
            var services = new ServiceCollection();
            
            var config = new ConfigurationBuilder()
                .AddUserSecrets(GetType().Assembly)
                .Build();

            services.Configure<DifyAIOptions>(config.GetSection("DifyAI"));

            services.AddDifyAIService();

            var app = services.BuildServiceProvider();
            _difyAIService = app.GetRequiredService<IDifyAIService>();
        }
	}
}

