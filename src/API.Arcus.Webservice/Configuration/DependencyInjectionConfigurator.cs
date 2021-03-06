using System.Collections.Generic;
using System.Reflection;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Concrete.Command;
using API.Arcus.Infrastructure.Concrete.Data;
using API.Arcus.Infrastructure.Concrete.Query;
using API.Arcus.Infrastructure.Configuration;
using API.Arcus.Infrastructure.Dto.Note;
using API.Arcus.Infrastructure.Dto.User;
using API.Arcus.Infrastructure.Mapping;
using API.Arcus.Infrastructure.Repository;
using API.Arcus.Webservice.Validators;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Arcus.Webservice.Configuration
{
	public class DependencyInjectionConfigurator : IDependencyInjectionConfigurator
	{
		public void Configure(IServiceCollection services, IConfiguration config)
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
			
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

			services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

			services.AddTransient<IValidator<UserPostRequestDto>, UserValidator>();
			services.AddTransient<IValidator<NotePostRequestDto>, NoteValidator>();

			services.AddTransient<IRequestHandler<CreateNoteCommand, Note>, CreateNoteCommandHandler>();
			services.AddTransient<IRequestHandler<CreateUserCommand, User>, CreateUserCommandHandler>();
			services.AddTransient<IRequestHandler<GetNoteByUserIdQuery, IEnumerable<Note>>, GetNoteByUserIdQueryHandler>();
			services.AddTransient<IRequestHandler<GetUserByEmailQuery, User>, GetUserByEmailQueryHandler>();
		}
	}
}