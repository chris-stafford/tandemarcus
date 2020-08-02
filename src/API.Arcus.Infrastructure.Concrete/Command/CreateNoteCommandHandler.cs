using System.Threading;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Repository;
using AutoMapper;
using MediatR;

namespace API.Arcus.Infrastructure.Concrete.Command
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Note>
    {
        private readonly INoteRepository _noteRepository;

        public CreateNoteCommandHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Note> Handle(CreateNoteCommand request, CancellationToken token)
        {
            await _noteRepository.AddAsync(request.Note);
            return request.Note;
        }
    }
}