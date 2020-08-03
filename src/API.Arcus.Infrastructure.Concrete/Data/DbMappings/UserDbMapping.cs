using API.Arcus.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Arcus.Infrastructure.Concrete.Data.DbMappings
{
	public class UserDbMapping : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> user)
		{
			user.HasIndex(e => e.EmailAddress)
				.HasName("IX_user_email")
				.IsUnique();

			user.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

			user.Property(e => e.EmailAddress).IsUnicode(false);

			user.Property(e => e.PhoneNumber).IsUnicode(false);
		}
	}
}