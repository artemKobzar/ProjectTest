using ProjectTest.Application.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTest.Domain;

namespace ProjectTest.Persistence.Services
{
    public class MessageReportEventArgs: EventArgs
    {
        public UserJoinPassportDto User { get; }
        //public string Identifier { get; }
        public MessageReportEventArgs(UserJoinPassportDto user)
        {
            User = user;
            //Identifier = identifier;
        }
        //public Guid Id { get; set; }
    }
}
//private UserDto _userJoinPassportDto;
//public UserReportEventArgs(UserDto value)
//{
//    _userJoinPassportDto = value;
//}
//public UserDto Value { get { return _userJoinPassportDto; } }
