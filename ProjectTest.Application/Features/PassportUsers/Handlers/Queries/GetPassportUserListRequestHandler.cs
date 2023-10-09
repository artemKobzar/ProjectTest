using AutoMapper;
using MediatR;
using ProjectTest.Application.DTOs.PassportUserDto;
using ProjectTest.Application.Features.PassportUsers.Requests.Queries;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Application.Features.Users.Requests.Queries;
using ProjectTest.Domain;

namespace ProjectTest.Application.Features.PassportUsers.Handlers.Queries
{
    public class GetPassportUserListRequestHandler: IRequestHandler<GetPassportUserListRequest,List<PassportUserListDto>>
    {
        public IPassportUserRepository _passportUserRepository;
        public IMapper _mapper;
        public GetPassportUserListRequestHandler(IPassportUserRepository passportUserRepository, IMapper mapper)
        {
            _passportUserRepository = passportUserRepository;
            _mapper = mapper;
        }
        public async Task<List<PassportUserListDto>> Handle(GetPassportUserListRequest request, CancellationToken cancellationToken)
        {
            var passportUsers = await _passportUserRepository.GetAll();
            return _mapper.Map<List<PassportUserListDto>>(passportUsers);
        }
    }
}
