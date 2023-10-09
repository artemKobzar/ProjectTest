using MediatR;
using ProjectTest.Application.DTOs.PassportUserDto;

namespace ProjectTest.Application.Features.PassportUsers.Requests.Commands
{
    public class UpdatePassportUserCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
        public PassportUserDto PassportUserDto { get; set; }
    }
}
