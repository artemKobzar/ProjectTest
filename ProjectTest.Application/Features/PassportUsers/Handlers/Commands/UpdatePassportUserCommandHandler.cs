using AutoMapper;
using MediatR;
using ProjectTest.Domain;
using ProjectTest.Application.Features.PassportUsers.Requests.Commands;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.Exceptions;
using ProjectTest.Application.DTOs.UserDto.Validators;
using ProjectTest.Application.Features.Users.Requests.Commands;

namespace ProjectTest.Application.Features.PassportUsers.Handlers.Commands
{
    public class UpdatePassportUserCommandHandler: IRequestHandler<UpdatePassportUserCommand, Unit>
    {
        public IPassportUserRepository _passportUserRepository;
        public IMapper _mapper;
        public UpdatePassportUserCommandHandler(IPassportUserRepository passportUserRepository, IMapper mapper)
        {
            _passportUserRepository = passportUserRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdatePassportUserCommand request, CancellationToken cancellationToken)
        {
            var passportUser = await _passportUserRepository.Get(request.Id);
            if (passportUser == null || passportUser.Id != request.Id)
            {
                throw new NotFoundException(nameof(PassportUser), request.Id);
            }

            _mapper.Map(request.PassportUserDto, passportUser);
            await _passportUserRepository.Update(passportUser);
            return Unit.Value;
        }
    }
}
