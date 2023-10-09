using AutoMapper;
using MediatR;
using ProjectTest.Domain;
using ProjectTest.Application.Features.PassportUsers.Requests.Commands;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.Exceptions;
using ProjectTest.Application.DTOs.UserDto.Validators;
using ProjectTest.Application.Features.Users.Requests.Commands;
using ProjectTest.Application.DTOs.PassportUserDto.Validators;

namespace ProjectTest.Application.Features.PassportUsers.Handlers.Commands
{
    public class CreatePassportUserCommandHandler: IRequestHandler<CreatePassportUserCommand, Guid>
    {
        public IPassportUserRepository _passportUserRepository;
        public IMapper _mapper;
        public CreatePassportUserCommandHandler(IPassportUserRepository passportUserRepository, IMapper mapper)
        {
            _passportUserRepository = passportUserRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreatePassportUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePassportUserValidator();
            var validationResult = await validator.ValidateAsync(request.CreatePassportUserDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            var passportUser = _mapper.Map<PassportUser>(request.CreatePassportUserDto);
            passportUser = await _passportUserRepository.Add(passportUser);
            return passportUser.Id;
        }
    }
}
