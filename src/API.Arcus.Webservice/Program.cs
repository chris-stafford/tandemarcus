using System;
using API.Arcus.Infrastructure.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Formatting.Compact;
using Serilog.Sinks.RollingFile;
using API.Arcus.Webservice.Configuration;

namespace API.Arcus.Webservice
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			using(var sink = new RollingFileSink("Logger.json", new CompactJsonFormatter(), 1000000, 50))
			{
				Log.Logger = new LoggerConfiguration()
					.MinimumLevel.Debug()
					.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
					.Enrich.FromLogContext()
					.Enrich.WithExceptionDetails()
					.WriteTo.Console()
					.WriteTo.Sink(sink)
					.CreateLogger();
			}

			try
			{
				Log.Information("Starting web host");
				BuildHostBuilder(args).Run();
			}
			catch (Exception ex)
			{
				Log.Error(ex, "Unexpected error");
				throw;
			}
		}

		/// <summary>
		/// Runtime method for creating startup
		/// </summary>
		public static IWebHost BuildHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
			.UseStartup<Startup>()
			.ConfigureServices(service =>
			{
				service.AddTransient<IDependencyInjectionConfigurator>(serviceProvider =>
					new DependencyInjectionConfigurator());
			}).Build();
	}
}