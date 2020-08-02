using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Dto.Note;
using MediatR;

namespace API.Arcus.Infrastructure.Concrete.Command
{
    public class CreateNoteCommand : IRequest<Note>
    {
        public Note Note { get; set; }
    }
}