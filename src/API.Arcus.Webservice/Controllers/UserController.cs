using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Concrete.Command;
using API.Arcus.Infrastructure.Concrete.Query;
using API.Arcus.Infrastructure.Dto.User;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Arcus.Webservice.Controllers
{
	[Route("user")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;
		
		public UserController(IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_mediator = mediator;
		}

		[HttpGet]
		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
		public async Task<ActionResult<UserGetResponseDto>> Get(
            [Required, FromQuery] string email)
		{
			try
			{
				var user = await _mediator.Send(new GetUserByEmailQuery { Email = email });

				if (user == null)
				{
					return NotFound();
				}

				return _mapper.Map<UserGetResponseDto>(user);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
		public async Task<ActionResult<UserPostResponseDto>> Post(
			[Required, FromBody] UserPostRequestDto userDto)
		{
			try
			{
				var userMap = _mapper.Map<User>(userDto);

				var user = await _mediator.Send(new CreateUserCommand
				{
					User = userMap 
				});

				return new UserPostResponseDto
				{
					Id = user.Id
				};
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}