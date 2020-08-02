using API.Arcus.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Arcus.Infrastructure.Concrete.Data.DbMappings
{
	public class NoteDbMapping : IEntityTypeConfiguration<Note>
	{
		public void Configure(EntityTypeBuilder<Note> note)
		{
			note.HasIndex(e => e.UserId)
				.HasName("IX_note");

			note.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

			note.HasOne(d => d.User)
				.WithMany(p => p.Note)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_note_user");
		}
	}
}