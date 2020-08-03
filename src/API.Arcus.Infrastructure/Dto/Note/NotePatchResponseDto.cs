using System;

namespace API.Arcus.Infrastructure.Dto.Note
{
	public class NotePatchResponseDto
	{
		public Guid Id { get; set; }

		public Guid UserId { get; set; }

		public string NoteText { get; set; }
	}
}