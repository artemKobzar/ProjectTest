using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.DTOs.PassportUserDto
{
    public class PassportUserListDto
    {
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public Guid UserId { get; set; }
    }
}
