using ProjectTest.Application.DTOs.PassportUserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.Contracts.Persistence
{
    public interface ISPPassportUserRepository
    {
        Task<CreatePassportUserDto> AddPassportUser(CreatePassportUserDto passport);
    }
}
