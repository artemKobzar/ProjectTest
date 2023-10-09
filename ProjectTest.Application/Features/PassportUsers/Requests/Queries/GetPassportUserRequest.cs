using MediatR;
using ProjectTest.Application.DTOs.PassportUserDto;

namespace ProjectTest.Application.Features.PassportUsers.Requests.Queries
{
    public class GetPassportUserRequest: IRequest<PassportUserDto>
    {
        public Guid Id { get; set; }
    }
}
