using System.Collections.Generic;
using API.Arcus.Domain.Model;
using AutoFixture;

namespace API.Arcus.Infrastructure.Test
{
	public class UserObjectsMock : ICustomization
	{
		public void Customize(IFixture fixture)
		{
			var users = new List<User>()
			{
				new User
				{
					FirstName = "Chris",
					MiddleName = "C",
					LastName = "Stafford",
					EmailAddress = "christafford@gmail.com",
					PhoneNumber = "(541) 337-1256"
				},
				new User
				{
					FirstName = "Bob",
					MiddleName = "deMark",
					LastName = "Smith",
					EmailAddress = "bobsmith@yahoo.com",
					PhoneNumber = "(123) 555-5555"
				}
			};

			fixture.Register(() => users);
		}
	}
}