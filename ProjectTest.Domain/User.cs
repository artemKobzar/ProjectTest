using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectTest.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public PassportUser Passport { get; set; }
    }
}
