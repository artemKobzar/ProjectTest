using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Application.DTOs.PassportUserDto;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Application.Features.PassportUsers.Requests.Commands;
using ProjectTest.Application.Features.PassportUsers.Requests.Queries;
using ProjectTest.Application.Features.Users.Requests.Commands;
using ProjectTest.Application.Features.Users.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportUsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PassportUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<PassportUsersController>
        [HttpGet]
        public async Task<ActionResult<List<PassportUserListDto>>> Get()
        {
            var passportUsers = await _mediator.Send(new GetPassportUserListRequest());

            return Ok(passportUsers);
        }

        // GET api/<PassportUsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PassportUserDto>> Get(Guid id)
        {
            var passportUser = await _mediator.Send(new GetPassportUserRequest { Id = id });
            return Ok(passportUser);
        }

        // POST api/<PassportUsersController>
        [HttpPost]
        public async Task<ActionResult> CreatePassportUser([FromBody] CreatePassportUserDto passportUser)
        {
            var command = new CreatePassportUserCommand { CreatePassportUserDto = passportUser };
            var response = await _mediator.Send(command);
            //return Ok(response);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, response);
        }

        // PUT api/<PassportUsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] PassportUserDto passportUser)
        {
            var command = new UpdatePassportUserCommand { PassportUserDto = passportUser };
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<PassportUsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeletePassportUserCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
