using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Arcus.Infrastructure.Concrete.Query
{
	public class GetNoteByUserIdQueryHandler : IRequestHandler<GetNoteByUserIdQuery, IEnumerable<Note>>
	{
		private readonly IRepository<Note> _repository;

		public GetNoteByUserIdQueryHandler(IRepository<Note> repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Note>> Handle(GetNoteByUserIdQuery request, CancellationToken cancellationToken)
		{
			return await _repository.GetAll()
				.Where(x => x.User.Id == request.UserId)
				.ToListAsync();
		}
	}
}