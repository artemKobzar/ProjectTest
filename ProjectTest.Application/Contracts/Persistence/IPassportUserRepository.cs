using ProjectTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.Contracts.Persistence
{
    public interface IPassportUserRepository: IGenericRepository<PassportUser>
    {
        //Task<PassportUser> GetPassportUserWithUser (Guid id);
    }
}
