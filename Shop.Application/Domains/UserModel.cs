using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Shop.Application.Domains
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
      
    }
}
