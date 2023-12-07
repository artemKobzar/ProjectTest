using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.DTOs.PassportUserDto;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Application.Features.Users.Requests.Commands;

namespace ProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPUserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISPUserRepository _sPUserRepository;
        private readonly ISPPassportUserRepository _sPPassportUserRepository;
        public SPUserController(IMediator mediator, ISPUserRepository sPUserRepository, ISPPassportUserRepository sPPassportUserRepository)
        {
            _mediator = mediator;
            _sPUserRepository = sPUserRepository;
            _sPPassportUserRepository = sPPassportUserRepository;
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser([FromBody] CreateUserDto user)
        {
            var us = await _sPUserRepository.AddUser(user);

            return Ok();
        }

        [HttpPost("AddPassportUser")]
        public async Task<ActionResult> AddPassportUser([FromBody] CreatePassportUserDto passport)
        {
            var us = await _sPPassportUserRepository.AddPassportUser(passport);

            return Ok();
        }

        [HttpGet("GetUserWithPassportFiltering")]
        public async Task<ActionResult> GetUserWithPassportFiltering(
            string? firstName, string? lastName, string? nation, string? gender, string? sortOption)
        {
            var users = await _sPUserRepository.GetUserWithPassportFiltering(firstName, lastName, nation, gender, sortOption);

            return Ok(users);
        }
    }
}
