using System.Threading;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Repository;
using MediatR;

namespace API.Arcus.Infrastructure.Concrete.Command
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
	{
		private readonly IRepository<User> _repository;

		public CreateUserCommandHandler(IRepository<User> repository)
		{
			_repository = repository;
		}

		public async Task<User> Handle(CreateUserCommand request, CancellationToken token)
		{
			await _repository.AddAsync(request.User);
			return request.User;
		}
	}
}