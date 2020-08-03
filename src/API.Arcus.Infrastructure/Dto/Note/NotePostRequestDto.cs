using System;

namespace API.Arcus.Infrastructure.Dto.Note
{
	public class NotePostRequestDto
	{
		public Guid UserId { get; set; }

		public string NoteText { get; set; }
	}
}