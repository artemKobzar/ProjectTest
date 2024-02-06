using ProjectTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTest.Application.Contracts.Persistence;

namespace ProjectTest.Persistence.Repositories
{
    public class ReportEventServiceRepository: IReportEventServiceRepository
    {
        private readonly ProjectTestDbContext _dbContext;
        public ReportEventServiceRepository(ProjectTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<EventMessageResult> Add(EventMessageResult entity)
        {
            await _dbContext.EventMessageResults.AddAsync(entity);
            Thread.Sleep(2000);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
