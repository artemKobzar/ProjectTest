using ProjectTest.Application.DTOs.UserDto.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.DTOs.UserDto
{
    public class UserJoinPassportDto
    {
        [CsvGenerator (Heading = "First name")]
        public string FirstName { get; set; }

        [CsvGenerator(Heading = "Last name")]
        public string LastName { get; set; }

        [CsvGenerator(Heading = "Phone number")]
        public string PhoneNumber { get; set; }

        [CsvGenerator(Heading = "Address")]
        public string Address { get; set; }

        [CsvGenerator(Heading = "Gender")]
        public string Gender { get; set; }

        [CsvGenerator(Heading = "Nationality")]
        public string Nationality { get; set; }

        [CsvGenerator(Heading = "Valid date")]
        public DateOnly ValidDate { get; set; }
    }
}
