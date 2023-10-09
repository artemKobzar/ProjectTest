using AutoMapper;
using MediatR;
using ProjectTest.Application.DTOs.UserDto.Validators;
using ProjectTest.Application.Exceptions;
using ProjectTest.Application.Features.Users.Requests.Commands;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.Features.Users.Handlers.Commands
{
    public class UpdateUserCommandHandler: IRequestHandler<UpdateUserCommand, Unit>
    {
        public IUserRepository _userRepository;
        public IMapper _mapper;
        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserValidator();
            var validationResult = await validator.ValidateAsync(request.UserDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            
            var user = await _userRepository.Get(request.Id);
            if (user == null || user.Id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            _mapper.Map(request.UserDto, user);
            await _userRepository.Update(user);
            return Unit.Value;
        }
    }
}
