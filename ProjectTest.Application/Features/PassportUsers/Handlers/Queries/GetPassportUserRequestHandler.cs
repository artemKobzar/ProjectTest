using AutoMapper;
using MediatR;
using ProjectTest.Application.DTOs.PassportUserDto;
using ProjectTest.Application.Features.PassportUsers.Requests.Queries;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Application.Features.Users.Requests.Queries;
using ProjectTest.Application.Exceptions;
using ProjectTest.Domain;

namespace ProjectTest.Application.Features.PassportUsers.Handlers.Queries
{
    public class GetPassportUserRequestHandler: IRequestHandler<GetPassportUserRequest, PassportUserDto>
    {
        public IPassportUserRepository _passportUserRepository;
        public IMapper _mapper;
        public GetPassportUserRequestHandler(IPassportUserRepository passportUserRepository, IMapper mapper)
        {
            _passportUserRepository = passportUserRepository;
            _mapper = mapper;
        }
        public async Task<PassportUserDto> Handle(GetPassportUserRequest request, CancellationToken cancellationToken)
        {
            var passportUser = await _passportUserRepository.Get(request.Id);
            if (passportUser == null || passportUser.Id != request.Id)
            {
                throw new NotFoundException(nameof(PassportUser), request.Id);
            }
            return _mapper.Map<PassportUserDto>(passportUser);
        }
    }
}
