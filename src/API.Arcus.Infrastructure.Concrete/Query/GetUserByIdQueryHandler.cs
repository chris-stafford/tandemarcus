using System.Threading;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Arcus.Infrastructure.Concrete.Query
{
	public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
	{
		private readonly IRepository<User> _repository;

		public GetUserByIdQueryHandler(IRepository<User> respository)
		{
			_repository = respository;
		}

		public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			return await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == request.Id);
		}
	}
}