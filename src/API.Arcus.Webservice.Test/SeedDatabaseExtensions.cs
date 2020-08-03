using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Concrete.Data;
using Microsoft.Extensions.DependencyInjection;

namespace API.Arcus.Webservice.Test
{
	public static class SeedDataBaseExtension
	{
		public static IServiceCollection SeedDataBase(this IServiceCollection services)
		{
			using var scope = services.BuildServiceProvider().CreateScope();
			using var db = scope.ServiceProvider.GetRequiredService<ArcusContext>();

			db.Database.EnsureCreated();
			db.User.Add(new User
			{
				FirstName = "Chris",
				MiddleName = "Colin",
				LastName = "Stafford",
				EmailAddress = "christafford@gmail.com",
				PhoneNumber = "(541) 337-1256"
			});

			db.SaveChanges();
			return services;
		}
	}
}