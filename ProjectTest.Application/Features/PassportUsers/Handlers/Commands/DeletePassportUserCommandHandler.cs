using AutoMapper;
using MediatR;
using ProjectTest.Domain;
using ProjectTest.Application.Features.PassportUsers.Requests.Commands;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.Exceptions;
using ProjectTest.Application.Features.Users.Requests.Commands;

namespace ProjectTest.Application.Features.PassportUsers.Handlers.Commands
{
    public class DeletePassportUserCommandHandler: IRequestHandler<DeletePassportUserCommand, Unit>
    {
        public IPassportUserRepository _passportUserRepository;
        public IMapper _mapper;
        public DeletePassportUserCommandHandler(IPassportUserRepository passportUserRepository, IMapper mapper)
        {
            _passportUserRepository = passportUserRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeletePassportUserCommand request, CancellationToken cancellationToken)
        {
            var passportUser = await _passportUserRepository.Get(request.Id);

            if (passportUser  == null)
            {
                throw new NotFoundException(nameof(PassportUser), request.Id);
            }
            await _passportUserRepository.Delete(passportUser);
            return Unit.Value;
        }
    }
}
