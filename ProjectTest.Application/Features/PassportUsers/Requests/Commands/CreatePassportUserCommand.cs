using MediatR;
using ProjectTest.Application.DTOs.PassportUserDto;

namespace ProjectTest.Application.Features.PassportUsers.Requests.Commands
{
    public class CreatePassportUserCommand: IRequest<Guid>
    {
        public Guid Id { get; set; }
        public CreatePassportUserDto CreatePassportUserDto { get; set; }
    }
}
