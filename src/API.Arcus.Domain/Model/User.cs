using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Arcus.Domain.Model
{
	[Table("user")]
    public partial class User
    {
        public User()
        {
            Note = new HashSet<Note>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("first_name")]
        [StringLength(1000)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(1000)]
        public string LastName { get; set; }
        [Column("phone_number")]
        [StringLength(1000)]
        public string PhoneNumber { get; set; }
        [Column("email_address")]
        [StringLength(1000)]
        public string EmailAddress { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Note> Note { get; set; }
    }
}
