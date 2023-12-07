using Microsoft.EntityFrameworkCore;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.DTOs.PassportUserDto;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Persistence.Repositories
{
    public class SPPassportUserRepository: ISPPassportUserRepository
    {
        private readonly ProjectTestDbContext _dbContext;
        public SPPassportUserRepository(ProjectTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        async Task<CreatePassportUserDto> ISPPassportUserRepository.AddPassportUser(CreatePassportUserDto passport)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                $"EXECUTE AddUser  @gender = {passport.Gender}, @nationality = {passport.Nationality}, @validDate = {passport.ValidDate}, @userId = {passport.UserId}");
          
            return passport;
        }
    }
}
