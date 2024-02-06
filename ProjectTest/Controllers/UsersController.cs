using CsvHelper.Configuration;
using CsvHelper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Application.Features.Users.Requests.Commands;
using ProjectTest.Application.Features.Users.Requests.Queries;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<UsersController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<UserListDto>>> Get()
        {
            var users = await _mediator.Send(new GetUserListRequest());

            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(Guid id)
        {
            var user = await _mediator.Send(new GetUserRequest { Id = id });
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserDto user)
        {
            var command = new CreateUserCommand { CreateUserDto = user };
            var response = await _mediator.Send(command);
            //return Ok(response);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, response);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] UserDto user)
        {
            var command = new UpdateUserCommand {UserDto = user};
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand { Id = id};
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("/UserWithPassport/id", Name = "Event")]
        public async Task<ActionResult<UserJoinPassportDto>> GetUserWithPassport(Guid id)
        {
            var user = await _mediator.Send(new GetUserWithPassportRequest { Id = id });
            return Ok(user);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("/UserWithPassportFilter", Name = "Filter")]
        public async Task<ActionResult<List<UserListDto>>> GetUserWithPassportFiltering(string? searchTerm, string? sortColumn, string? sortOrder)
        {
            var users = await _mediator.Send(new GetUserWithPassportListFilteringRequest(searchTerm, sortColumn, sortOrder));

            return Ok(users);
        }
    }
}
