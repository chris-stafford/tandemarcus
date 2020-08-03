using System.Net.Http;
using API.Arcus.Infrastructure.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace API.Arcus.Webservice.Test
{
	public class TestClientProvider
	{
		private readonly TestServer Server;

		public HttpClient Client { get; private set; }

		public TestClientProvider()
		{
			var host = new WebHostBuilder()
				.UseStartup<Startup>()
				.ConfigureServices(service =>
				{
					service.AddTransient<IDependencyInjectionConfigurator>(serviceProvider =>
						new DependencyInjectionConfiguratorMock());
				});

			Server = new TestServer(host);

			Client = Server.CreateClient();
		}

		public void Dispose()
		{
			Server?.Dispose();
			Client?.Dispose();
		}
	}
}