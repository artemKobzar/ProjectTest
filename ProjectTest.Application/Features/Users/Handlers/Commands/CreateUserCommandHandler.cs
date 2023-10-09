using AutoMapper;
using MediatR;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Domain;
using ProjectTest.Application.Features.Users.Requests.Commands;
using ProjectTest.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTest.Application.DTOs.UserDto.Validators;
using System.Data;
using ProjectTest.Application.Exceptions;

namespace ProjectTest.Application.Features.Users.Handlers.Commands
{
    public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, Guid>
    {
        public IUserRepository _userRepository;
        public IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken) 
        {
            var validator = new CreateUserValidator();
            var validationResult = await validator.ValidateAsync(request.CreateUserDto);

            if(validationResult.IsValid==false)
            {
                throw new ValidationException(validationResult);
            }

            var user = _mapper.Map<User>(request.CreateUserDto);
            user = await _userRepository.Add(user);
            return user.Id;
        }
    }
}
