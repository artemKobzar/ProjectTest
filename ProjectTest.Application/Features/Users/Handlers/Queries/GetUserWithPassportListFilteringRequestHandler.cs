using AutoMapper;
using MediatR;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Application.Features.Users.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.Features.Users.Handlers.Queries
{
    public class GetUserWithPassportListFilteringRequestHandler: 
        IRequestHandler<GetUserWithPassportListFilteringRequest, List<UserJoinPassportDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserWithPassportListFilteringRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserJoinPassportDto>> Handle(GetUserWithPassportListFilteringRequest request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUserWithPassportFiltering(request.SearchTerm, request.SortColumn, request.SortOrder);
            return _mapper.Map<List<UserJoinPassportDto>>(users);
        }
    }
}
