using AutoMapper;
using ProjectTest.Domain;
using MediatR;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Application.Features.Users.Requests.Queries;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.Features.Users.Handlers.Queries
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserWithPassport(request.Id);
            if (user == null || user.Id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            return _mapper.Map<UserDto>(user);
        }
    }
}
