using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Concrete.Command;
using API.Arcus.Infrastructure.Concrete.Query;
using API.Arcus.Infrastructure.Dto.Note;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Arcus.Webservice.Controllers
{
	[Route("user/{user-id}/note")]
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

		[HttpGet]
		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
		public async Task<ActionResult<List<NoteGetResponseDto>>> Get(
			[Required, FromRoute(Name="user-id")] Guid userId)
		{
			try
			{
				var response = await _mediator.Send(new GetNoteByUserIdQuery { UserId = userId });

				return response
					.Select(x => _mapper.Map<NoteGetResponseDto>(x))
					.ToList();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
		public async Task<ActionResult<NotePostResponseDto>> Post(
            [FromRoute(Name="user-id")] Guid userId,
			[Required, FromBody] NotePostRequestDto noteDto)
		{
			try
			{
                var domainNote = _mapper.Map<Note>(noteDto);
                
                domainNote.UserId = userId;

				var note = await _mediator.Send(new CreateNoteCommand
				{
					Note = domainNote
				});

                if (note == null)
                {
                    return NotFound();
                }

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