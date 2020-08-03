using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Arcus.Domain.Model
{
	[Table("note")]
	public class Note
	{
		[Key]
		[Column("id")]
		public Guid Id { get; set; }
		[Column("user_id")]
		public Guid UserId { get; set; }
		[Required]
		[Column("note_text")]
		[StringLength(1000)]
		public string NoteText { get; set; }

		[ForeignKey(nameof(UserId))]
		[InverseProperty("Note")]
		public virtual User User { get; set; }
	}
}