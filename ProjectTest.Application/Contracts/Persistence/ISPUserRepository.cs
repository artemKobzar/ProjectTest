using ProjectTest.Application.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.Contracts.Persistence
{
    public interface ISPUserRepository
    {
        Task<CreateUserDto> AddUser(CreateUserDto user);
        Task<IEnumerable<UserJoinPassportDto>> GetUserWithPassportFiltering(
            string? firstName, string? lastName, string? nation, string? gender, string? sortOption);
    }
}
