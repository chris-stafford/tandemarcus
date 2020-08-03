using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Concrete.Command;
using API.Arcus.Infrastructure.Concrete.Configuration;
using API.Arcus.Infrastructure.Concrete.Data;
using API.Arcus.Infrastructure.Concrete.Query;
using API.Arcus.Infrastructure.Dto.Note;
using API.Arcus.Infrastructure.Dto.User;
using API.Arcus.Infrastructure.Repository;
using API.Arcus.Webservice.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Arcus.Webservice
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddMvc().AddFluentValidation();
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
			services.ConfigureConcreteServices(Configuration);
			
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

			services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

			services.AddTransient<IValidator<UserPostRequestDto>, UserValidator>();
			services.AddTransient<IValidator<NotePostRequestDto>, NoteValidator>();

			services.AddTransient<IRequestHandler<CreateNoteCommand, Note>, CreateNoteCommandHandler>();
			services.AddTransient<IRequestHandler<CreateUserCommand, User>, CreateUserCommandHandler>();
			services.AddTransient<IRequestHandler<GetNoteByUserIdQuery, IEnumerable<Note>>, GetNoteByUserIdQueryHandler>();
			services.AddTransient<IRequestHandler<GetUserByIdQuery, User>, GetUserByIdQueryHandler>();
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