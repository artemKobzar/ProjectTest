using MediatR;
using ProjectTest.Application.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.Features.Users.Requests.Commands
{
    public class CreateUserCommand: IRequest<Guid>
    {
        public Guid Id { get; set; }
        public CreateUserDto CreateUserDto { get; set; }
    }
}
