using MediatR;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.Features.Users.Requests.Commands
{
    public class UpdateUserCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
        public UserDto UserDto { get; set; }
        //public UpdateUserDto UpdateUserDto { get; set; }
    }
}
