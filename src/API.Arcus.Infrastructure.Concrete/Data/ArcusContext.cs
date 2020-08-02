using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Concrete.Data.DbMappings;
using Microsoft.EntityFrameworkCore;

namespace API.Arcus.Infrastructure.Concrete.Data
{
	public class ArcusContext : DbContext
	{
		public ArcusContext(DbContextOptions<ArcusContext> options) : base(options)
		{
		}

		public virtual DbSet<Note> Note { get; set; }
		
		public virtual DbSet<User> User { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder
				.ApplyConfiguration(new UserDbMapping())
				.ApplyConfiguration(new NoteDbMapping());
		}
	}
}