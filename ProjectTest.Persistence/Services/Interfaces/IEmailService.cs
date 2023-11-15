using ProjectTest.Application.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Persistence.Services.Interfaces
{
    public interface IEmailService
    {
        public Task CreateMessageResult(UserJoinPassportDto user);
    }
}
