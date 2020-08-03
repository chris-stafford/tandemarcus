using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Arcus.Domain.Model
{
	[Table("user")]
	public class User
	{
		public User()
		{
			Note = new HashSet<Note>();
		}

		[Key]
		[Column("id")]
		public Guid Id { get; set; }
		[Required]
		[Column("first_name")]
		[StringLength(100)]
		public string FirstName { get; set; }
		[Column("middle_name")]
		[StringLength(100)]
		public string MiddleName { get; set; }
		[Required]
		[Column("last_name")]
		[StringLength(100)]
		public string LastName { get; set; }
		[Column("phone_number")]
		[StringLength(50)]
		public string PhoneNumber { get; set; }
		[Required]
		[Column("email_address")]
		[StringLength(500)]
		public string EmailAddress { get; set; }

		[InverseProperty("User")]
		public virtual ICollection<Note> Note { get; set; }
	}
}
