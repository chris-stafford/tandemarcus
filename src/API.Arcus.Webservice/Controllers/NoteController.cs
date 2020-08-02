using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Concrete.Command;
using API.Arcus.Infrastructure.Dto.Note;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Arcus.Webservice.Controllers
{
    [Route("note")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public NoteController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("note-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<NoteGetResponseDto>> Get(
            [Required, FromRoute(Name = "note-id")] Guid noteId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<NotePostResponseDto>> Post(
            [Required, FromBody] NotePostRequestDto dto)
        {
            try
            {
                var note = await _mediator.Send(new CreateNoteCommand
                {
                    Note = _mapper.Map<Note>(dto)
                });

                return new NotePostResponseDto
                {
                    Id = note.Id
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}