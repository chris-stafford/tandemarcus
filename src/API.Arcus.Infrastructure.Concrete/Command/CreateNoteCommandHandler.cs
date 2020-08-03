using System.Threading;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Repository;
using MediatR;

namespace API.Arcus.Infrastructure.Concrete.Command
{
	public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Note>
	{
		private readonly IRepository<Note> _repository;

		public CreateNoteCommandHandler(IRepository<Note> repository)
		{
			_repository = repository;
		}

		public async Task<Note> Handle(CreateNoteCommand request, CancellationToken token)
		{
			await _repository.AddAsync(request.Note);
			return request.Note;
		}
	}
}