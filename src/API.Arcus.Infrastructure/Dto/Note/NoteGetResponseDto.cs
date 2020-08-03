using System;
using API.Arcus.Infrastructure.Dto.User;

namespace API.Arcus.Infrastructure.Dto.Note
{
	public class NoteGetResponseDto
	{
		public Guid Id { get; set; }

		public UserGetResponseDto User { get; set; }

		public string NoteText { get; set; }
	}
}