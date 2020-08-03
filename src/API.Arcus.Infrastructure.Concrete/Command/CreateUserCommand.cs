using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Dto.User;
using MediatR;

namespace API.Arcus.Infrastructure.Concrete.Command
{
	public class CreateUserCommand : IRequest<User>
	{
		public User User { get; set; }
	}
}