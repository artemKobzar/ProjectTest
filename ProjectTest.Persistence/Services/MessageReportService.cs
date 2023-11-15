using ProjectTest.Application.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTest.Domain;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.Features.Users.Requests.Queries;
using AutoMapper;
using ProjectTest.Persistence.Services;
using ProjectTest.Persistence.Repositories;

namespace ProjectTest.Persistence.Services
{
    public class MessageReportService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public event EventHandler<MessageReportEventArgs> UserRetrieved;

        public MessageReportService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        protected virtual void OnUserRetrieved(MessageReportEventArgs e)
        {
            if (UserRetrieved != null )
                UserRetrieved(this, e);

        }
        public async Task<UserJoinPassportDto> GetUser(Guid id)
        {
            var user = await _userRepository.GetUserWithPassport(id);
            OnUserRetrieved(new MessageReportEventArgs(_mapper.Map<UserJoinPassportDto>(user)));
            return _mapper.Map<UserJoinPassportDto>(user);
        }
    }
}
//protected virtual void OnUserRetrieved(MessageReportEventArgs e)
//{
//    if (UserRetrieved != null)
//        UserRetrieved(this, new MessageReportEventArgs() { Id = e.Id });
//}
//public void GetUserWith(UserDto user)
// {
//     var e = new UserReportEventArgs(user);
//     OnUserReport(e);
// }
//protected virtual void OnUserReport(MessageReportEventArgs e)
//{
//    UserRetrieved?.Invoke(this, e);
//}

