using Microsoft.EntityFrameworkCore;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;
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
        public async  Task<List<UserJoinPassportDto>> GetUserWithPassport()
        {
            IQueryable<User> us = _dbContext.Users;
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
                    ValidDate = user.ValidDate
                });
            }         
            return ujpd;
        }
        public async Task<UserJoinPassportDto> GetUserWithPassport(Guid id)
        {
            var ujpd = await (from u in _dbContext.Users
                        join p in _dbContext.PassportUsers on u.Id equals p.UserId
                        where u.Id == id
                        select new UserJoinPassportDto
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            PhoneNumber = u.PhoneNumber,
                            Address = u.Address,
                            Gender = p.Gender,
                            Nationality = p.Nationality,
                            ValidDate = p.ValidDate
                        }).FirstOrDefaultAsync();
            return ujpd;
        }
        public async Task<List<UserJoinPassportDto>> GetUserWithPassportFiltering(string? searchTerm, string? sortColumn, string? sortOrder)
        {
            var users = await Task.FromResult(_dbContext.Users.Join(_dbContext.PassportUsers, u => u.Id, p => p.UserId, (u, p) => new { u, p })
                //.Where(x => x.u.FirstName.Contains(searchTerm) || x.u.LastName.Contains(searchTerm) 
                //|| x.p.Nationality.Contains(searchTerm)
                //|| x.p.Gender.Contains(searchTerm))
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

            List<UserJoinPassportDto> ujpd = new();
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
                    ValidDate = user.ValidDate
                });
            }
            IQueryable<UserJoinPassportDto> userQuery = ujpd.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                userQuery = userQuery.Where(u => u.FirstName.Contains(searchTerm) || u.LastName.Contains(searchTerm) ||
                u.Nationality.Contains(searchTerm) || u.Gender.Contains(searchTerm));
            }

            //Expression<Func<UserJoinPassportDto, object>> keySelector = GetSortProperty(sortColumn);
            if (sortOrder?.ToLower() == "descending")
            {
                userQuery = userQuery.OrderByDescending(GetSortProperty(sortColumn));
            }
            else
            {
                userQuery = userQuery.OrderBy(GetSortProperty(sortColumn));
            }

            return userQuery.ToList();
        }

        private static Expression<Func<UserJoinPassportDto, object>> GetSortProperty(string? sortColumn)
        {
            return sortColumn?.ToLower() switch
            {
                "name" => user => user.LastName,
                "date" => user => user.ValidDate,
                "nationality" => user => user.Nationality,
                _ => user => user.FirstName
            };
        }
    }
}
//public async Task<User> GetUserWithPassport(Guid id)
//{
//    var userPassport = await _dbContext.Users
//        //.Include(p => p.Passport).AsNoTracking()
//        .FirstOrDefaultAsync(p => p.Id == id);

//    return userPassport;
//}

