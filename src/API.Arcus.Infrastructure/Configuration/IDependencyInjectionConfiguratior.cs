using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Arcus.Infrastructure.Configuration
{
	 public interface IDependencyInjectionConfigurator
	{
		void Configure(IServiceCollection services, IConfiguration config);
	}
}
