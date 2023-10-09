using Microsoft.EntityFrameworkCore;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Persistence.Repositories
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        private readonly ProjectTestDbContext _dbContext;
        public UserRepository(ProjectTestDbContext dbContext): base (dbContext)
        {
            _dbContext = dbContext;
        }
        public async  Task<List<UserJoinPassportDto>> GetCsvUserWithPassport()
        {
            var users = await Task.FromResult(_dbContext.Users.Join(_dbContext.PassportUsers, u => u.Id, p => p.UserId, (u, p) => new {u, p})
                .Select(sel => new 
            {
                    sel.u.FirstName,
                    sel.u.LastName,
                    sel.u.PhoneNumber,
                    sel.u.Address,
                    sel.p.Gender,
                    sel.p.Nationality,
                    sel.p.ValidDate
                }).ToList());

            List<UserJoinPassportDto> ujpd =  new ();
            foreach (var user in users) 
            {
                ujpd.Add(new UserJoinPassportDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    Gender = user.Gender,
                    Nationality = user.Nationality,
                    ValidDate = user.ValidDate,
                });
            }
            return ujpd;
        }
        public async Task<User> GetUserWithPassport(Guid id)
        {
            var userPassport = await _dbContext.Users
                .Include(p => p.Passport).AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            return userPassport;
        }
    }
}

