using API.Arcus.Infrastructure.Concrete.Data;
using API.Arcus.Infrastructure.Mapping;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Arcus.Infrastructure.Concrete.Configuration
{
	public static class DIConfiguration
	{
		public static void ConfigureConcreteServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<ArcusContext>(
				options => options.UseSqlServer(config.GetConnectionString("ArcusDbConnection"))
			);

			var autoMapconfig = new MapperConfiguration(c =>
			{
				c.AddProfile<MappingProfile>();
				c.IgnoreSourceWhenNull();
			});
			
			services.AddSingleton(s => autoMapconfig.CreateMapper());
		}
	}
}