using System.Threading;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Repository;
using AutoMapper;
using MediatR;

namespace API.Arcus.Infrastructure.Concrete.Command
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
	{
		private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken token)
        {
            await _userRepository.AddAsync(request.User);
            return request.User;
        }
	}
}