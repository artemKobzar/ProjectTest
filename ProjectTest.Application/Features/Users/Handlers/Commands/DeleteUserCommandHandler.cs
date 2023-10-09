using AutoMapper;
using MediatR;
using ProjectTest.Application.Features.Users.Requests.Commands;
using ProjectTest.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTest.Application.Exceptions;
using ProjectTest.Domain;

namespace ProjectTest.Application.Features.Users.Handlers.Commands
{
    public class DeleteUserCommandHandler: IRequestHandler<DeleteUserCommand, Unit>
    {
        public IUserRepository _userRepository;
        public IMapper _mapper;
        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id);

            if (user == null) 
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            await _userRepository.Delete(user);
            return Unit.Value;
        }
    }
}
