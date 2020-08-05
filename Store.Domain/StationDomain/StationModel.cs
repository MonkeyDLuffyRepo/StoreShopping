using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.StationDomain
{
   public class StationModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }
        [JsonProperty("modificationDate")]
        public DateTime? ModificationDate { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("addressId")]
        public int? AddressId { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
