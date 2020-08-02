using System;

namespace API.Arcus.Infrastructure.Dto.User
{
	public class UserGetResponseDto
	{
		public Guid Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string PhoneNumber { get; set; }

		public string EmailAddress { get; set; }
	}
}