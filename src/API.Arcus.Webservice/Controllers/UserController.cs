using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Concrete.Command;
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

        [HttpGet("user-id")]
		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
		public async Task<ActionResult<User>> Get(
			[Required, FromRoute(Name = "user-id")] Guid userId)
		{
			throw new NotImplementedException();
		}

        [HttpPost]
		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
		public async Task<ActionResult<UserPostResponseDto>> Post(
			[Required, FromBody] UserPostRequestDto dto)
		{
			try
            {
                var user = await _mediator.Send(new CreateUserCommand
                {
                    User = _mapper.Map<User>(dto)
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