using System;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectTest.Persistence.Repositories
{
    public class PassportUserRepository: GenericRepository<PassportUser>, IPassportUserRepository
    {
        private readonly ProjectTestDbContext _dbContext;
        public PassportUserRepository(ProjectTestDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
        //public async Task<List<PassportUser>> GetCsvByJoin()
        //{
        //    var userWithPassport = await _dbContext.PassportUsers.Join(_dbContext.Users,
        //    p => p.UserId,
        //    u => u.Id,
        //    (p, u) => new
        //     {
        //        Gender = p.Gender,
        //        Nationality = p.Nationality,
        //        FirstName = u.FirstName,
        //        LastName = u.LastName
        //     }).ToListAsync();

        //    return userWithPassport;
        //}
        //public async Task<PassportUser> GetPassportUserWithUser (Guid id)
        //{
        //    var passportUser = await _dbContext.PassportUsers
        //        .Include(u => u.User)
        //        .FirstOrDefaultAsync (p => p.Id == id);

        //    return passportUser;
        //}
    }
}
