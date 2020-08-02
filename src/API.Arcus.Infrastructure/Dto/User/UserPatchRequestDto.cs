namespace API.Arcus.Infrastructure.Dto.User
{
	public class UserPatchRequestDto
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string PhoneNumber { get; set; }

		public string EmailAddress { get; set; }
	}
}