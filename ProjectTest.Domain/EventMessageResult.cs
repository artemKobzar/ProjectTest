using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Domain
{
    public class EventMessageResult
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int EventId { get; set; }
        //public EventType EventType { get; set; }
    }
}
