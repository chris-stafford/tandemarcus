using System;
using API.Arcus.Domain.Model;
using MediatR;

namespace API.Arcus.Infrastructure.Concrete.Query
{
	public class GetUserByIdQuery : IRequest<User>
	{
		public Guid Id { get; set; }
	}
}