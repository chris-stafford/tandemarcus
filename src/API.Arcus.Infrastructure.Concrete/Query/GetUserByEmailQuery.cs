using System;
using API.Arcus.Domain.Model;
using MediatR;

namespace API.Arcus.Infrastructure.Concrete.Query
{
	public class GetUserByEmailQuery : IRequest<User>
	{
		public string Email { get; set; }
	}
}