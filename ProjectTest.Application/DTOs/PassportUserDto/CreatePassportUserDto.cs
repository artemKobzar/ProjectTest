using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.DTOs.PassportUserDto
{
    public class CreatePassportUserDto
    {
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public DateOnly ValidDate { get; set; }
        public Guid UserId { get; set; }
    }
}
