using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.UserDomain
{
    public class UserModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }
        [JsonProperty("modificationDate")]
        public DateTime? ModificationDate { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
    }
}
