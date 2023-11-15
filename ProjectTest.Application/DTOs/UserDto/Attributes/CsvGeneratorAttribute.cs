using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.DTOs.UserDto.Attributes
{
    public class CsvGeneratorAttribute: Attribute
    {
        [DefaultValue(typeof(Color), "255, 0, 0")]
        public string Heading { get; set; }
    }
}
