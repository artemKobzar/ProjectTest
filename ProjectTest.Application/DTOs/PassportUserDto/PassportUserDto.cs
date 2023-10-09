using ProjectTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectTest.Application.DTOs.PassportUserDto
{
    public class PassportUserDto 
    {
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public DateOnly ValidDate { get; set; }
        public Guid UserId { get; set; }
        //public User User { get; set; }

    }
}
