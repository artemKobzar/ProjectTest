using AutoMapper;
using MediatR;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Application.Features.Users.Requests.Queries;
using ProjectTest.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.Features.Users.Handlers.Queries
{
    public class GetUserListCsvRequestHandler : IRequestHandler<GetUserListCsvRequest, List<UserJoinPassportDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserListCsvRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserJoinPassportDto>> Handle(GetUserListCsvRequest request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetCsvUserWithPassport();
            return _mapper.Map<List<UserJoinPassportDto>>(users);
        }
    }
}
