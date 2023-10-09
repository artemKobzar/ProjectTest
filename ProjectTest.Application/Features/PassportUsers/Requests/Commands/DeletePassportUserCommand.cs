using MediatR;


namespace ProjectTest.Application.Features.PassportUsers.Requests.Commands
{
    public class DeletePassportUserCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
