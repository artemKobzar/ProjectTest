using ProjectTest.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTest.Application.DTOs.UserDto;

namespace ProjectTest.Application.Contracts.Persistence
{
    public interface IUserRepository: IGenericRepository<User>
    {
        //Task<User> GetUserWithPassport(Guid id);
        Task <List<UserJoinPassportDto>> GetUserWithPassport();
        Task<UserJoinPassportDto> GetUserWithPassport(Guid id);
        Task <List<UserJoinPassportDto>> GetUserWithPassportFiltering(string? searchTerm, string? sortColumn, string? sortOrder);

    }
}
