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
    public class GetUserWithPassportRequestHandler : IRequestHandler<GetUserWithPassportRequest, UserJoinPassportDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPassportUserRepository _passportUserRepository;
        private readonly IMapper _mapper;
        public GetUserWithPassportRequestHandler(IUserRepository userRepository, IPassportUserRepository passportUserRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _passportUserRepository = passportUserRepository;
            _mapper = mapper;
        }
        public async Task<UserJoinPassportDto> Handle(GetUserWithPassportRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserWithPassport(request.Id);
            //if (user == null || user.Id != request.Id)
            //{
            //    throw new NotFoundException(nameof(User), request.Id);
            //}
            return _mapper.Map<UserJoinPassportDto>(user);
        }
    }
}
