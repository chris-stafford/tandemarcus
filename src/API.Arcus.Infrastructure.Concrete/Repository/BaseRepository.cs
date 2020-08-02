using System.Threading.Tasks;
using API.Arcus.Infrastructure.Concrete.Data;
using API.Arcus.Infrastructure.Repository;

namespace API.Arcus.Infrastructure.Concrete.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ArcusContext _context;

        public BaseRepository(ArcusContext context)
        {
            _context = context;
        }

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}