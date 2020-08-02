using System;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;

namespace API.Arcus.Infrastructure.Repository
{
	public interface IUserRepository
	{
		Task AddAsync(User user);

		Task<User> Get(Guid id);
	}
}