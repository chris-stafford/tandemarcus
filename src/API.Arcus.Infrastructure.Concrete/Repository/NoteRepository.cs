using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Concrete.Data;
using API.Arcus.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace API.Arcus.Infrastructure.Concrete.Services
{
	public class NoteRepository : INoteRepository
	{
        public readonly ArcusContext _context;

        public NoteRepository(ArcusContext context)
        {
            _context = context;
        }

		public async Task AddAsync(Note Note)
		{
			await _context.AddAsync(Note);
		}

		public async Task<IEnumerable<Note>> FindByEmailAsync(string email)
		{
			var notes = await _context.Note
				.Where(x => x.EmailAddress == email)
				.ToListAsync();
			
			return notes;
		}

		public async Task<Note> Get(Guid id)
		{
			var note = await _context.Note
				.Where(x => x.Id == id)
				.FirstOrDefaultAsync();
			
			return note;
		}
	}
}