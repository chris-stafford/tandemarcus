using System.Collections.Generic;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;

namespace API.Arcus.Infrastructure.Repository
{
    public interface INoteRepository
    {
        Task AddAsync(Note note);

		Task<IEnumerable<Note>> FindByEmailAsync(string email);
    }
}