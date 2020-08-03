using System;
using System.Collections.Generic;
using API.Arcus.Domain.Model;
using MediatR;

namespace API.Arcus.Infrastructure.Concrete.Query
{
	public class GetNoteByUserIdQuery : IRequest<IEnumerable<Note>>
	{
		public Guid UserId { get; set; }
	}
}