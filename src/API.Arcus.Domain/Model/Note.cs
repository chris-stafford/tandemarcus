using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Arcus.Domain.Model
{
	[Table("note")]
	public partial class Note
	{
		[Key]
		[Column("id")]
		public Guid Id { get; set; }

		[Column("user_id")]
		public Guid UserId { get; set; }

		[Column("name")]
		[StringLength(1000)]
		public string Name { get; set; }

		[Column("phone_number")]
		[StringLength(1000)]
		public string PhoneNumber { get; set; }

		[Column("email_address")]
		[StringLength(1000)]
		public string EmailAddress { get; set; }

		[ForeignKey(nameof(UserId))]
		[InverseProperty("Note")]
		public virtual User User { get; set; }
	}
}