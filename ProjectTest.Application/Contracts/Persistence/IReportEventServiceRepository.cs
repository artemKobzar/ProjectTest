using ProjectTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.Contracts.Persistence
{
    public interface IReportEventServiceRepository
    {
        public  Task<EventMessageResult> Add(EventMessageResult entity);
    }
}
