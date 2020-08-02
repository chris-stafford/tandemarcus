using API.Arcus.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Arcus.Infrastructure.Concrete.Data.DbMappings
{
	public class UserDbMapping : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> user)
		{
			user.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");
		}
	}
}