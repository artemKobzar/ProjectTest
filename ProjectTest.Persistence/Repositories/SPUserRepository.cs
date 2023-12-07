using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ProjectTest.Persistence.Repositories
{
    public class SPUserRepository: ISPUserRepository
    {
        private readonly ProjectTestDbContext _dbContext;
        public SPUserRepository(ProjectTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<CreateUserDto> ISPUserRepository.AddUser(CreateUserDto user)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                $"EXECUTE AddUser @firstName = {user.FirstName}, @lastName = {user.LastName}, @phoneNumber = {user.PhoneNumber}, @email = {user.Email}, @address = {user.Address}");

            return user;
        }

        async Task<IEnumerable<UserJoinPassportDto>> ISPUserRepository.GetUserWithPassportFiltering(
            string? firstName, string? lastName, string? nation, string? gender, string? sortOption)

        {
            var parameters = new[]
            {
                new SqlParameter("@firstName", firstName ?? (object)DBNull.Value),
                new SqlParameter("@lastName", lastName ?? (object)DBNull.Value),
                //new SqlParameter("@address", address ?? (object)DBNull.Value),
                new SqlParameter("@nationality", nation?? (object)DBNull.Value),
                new SqlParameter("@gender", gender ?? (object)DBNull.Value),
                new SqlParameter("@sortOption", sortOption ?? "FirstName")
            };

            var users = _dbContext.UserWithPassport.FromSqlRaw<UserJoinPassportDto>("EXECUTE GetUserWithPassportFiltering @firstName, @lastName, @nationality, @gender, @sortOption", parameters);
             //var users = await _dbContext.Database
             //   .SqlQueryRaw<UserJoinPassportDto>($"EXECUTE GetUserWithPassportFiltering @firstName, @lastName, @address, @nationality, @gender, @sortOption", parameters)
             //   .ToListAsync();
            return users;
        }
    }
}
//List<UserJoinPassportDto> ujpd = new();
//foreach (var user in users)
//{
//    ujpd.Add(new UserJoinPassportDto
//    {

//    });
//}
//IQueryable<UserJoinPassportDto> filteredUsers = ujpd.AsQueryable();
//return filteredUsers.ToList();