using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Domain
{
    public class PassportUser
    {
        public Guid Id { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        //[NotMapped]
        public DateOnly ValidDate { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
