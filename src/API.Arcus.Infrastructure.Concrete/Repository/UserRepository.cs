using System;
using System.Linq;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Concrete.Data;
using API.Arcus.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace API.Arcus.Infrastructure.Concrete.Services
{
	public class UserRepository : IUserRepository
	{
        public readonly ArcusContext _context;

        public UserRepository(ArcusContext context)
        {
            _context = context;
        }

		public async Task AddAsync(User user)
		{
			await _context.AddAsync(user);
		}

		public async Task<User> Get(Guid id)
		{
			var user = await _context.User
				.Where(x => x.Id == id)
				.FirstOrDefaultAsync();
			
			return user;
		}
	}
}