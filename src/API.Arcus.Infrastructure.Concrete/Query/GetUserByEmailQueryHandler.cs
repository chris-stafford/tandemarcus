using System.Threading;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Arcus.Infrastructure.Concrete.Query
{
	public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
	{
		private readonly IRepository<User> _repository;

		public GetUserByEmailQueryHandler(IRepository<User> respository)
		{
			_repository = respository;
		}

		public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
		{
			return await _repository.GetAll().FirstOrDefaultAsync(x => x.EmailAddress == request.Email);
		}
	}
}