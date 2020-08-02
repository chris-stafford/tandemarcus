using System;

namespace API.Arcus.Infrastructure.Dto.Note
{
	public class NotePatchResponseDto
	{
		public Guid Id { get; set; }

		public Guid UserId { get; set; }

		public string Name { get; set; }

		public string PhoneNumber { get; set; }

		public string EmailAddress { get; set; }
	}
}