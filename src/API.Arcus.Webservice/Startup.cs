using System;
using System.IO;
using System.Reflection;
using API.Arcus.Infrastructure.Configuration;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Arcus.Webservice
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IDependencyInjectionConfigurator dependencyInjectionConfiguration)
		{
			Configuration = configuration;
			_dependencyInjectionConfiguration = dependencyInjectionConfiguration;
		}

		public IConfiguration Configuration { get; }
		private readonly IDependencyInjectionConfigurator _dependencyInjectionConfiguration;

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddMvc()
				.AddFluentValidation();
#if DEBUG
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("TandemArCus",
					new OpenApiInfo()
					{
						Title = "Tandem Arcus API", Version = "1"
					});
				var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

				c.IncludeXmlComments(xmlCommentsFullPath);
			});
#endif
			_dependencyInjectionConfiguration.Configure(services, Configuration);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app)
		{
			app.UseRouting()
				.UseEndpoints(endpoints =>
				{
					endpoints.MapControllers();
				});
			app.UseDeveloperExceptionPage();
			app.UseSwagger()
				.UseSwaggerUI(setupAction =>
				{
					setupAction.SwaggerEndpoint("/swagger/TandemArCus/swagger.json", "Tandem Arcus API");
					setupAction.RoutePrefix = "";
				});
		}
	}
}