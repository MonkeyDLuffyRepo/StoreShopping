using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.VehiculeDomain
{
    public class VehiculeModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }
        [JsonProperty("modiicationDate")]
        public DateTime? ModificationDate { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("capacitySeat")]
        public int CapacitySeat { get; set; }
        [JsonProperty("availableSeat")]
        public int? AvailableSeat { get; set; }
        [JsonProperty("personId")]
        public int? PersonId { get; set; }
        [JsonProperty("typeId")]
        public int? TypeId { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("mark")]
        public string Mark { get; set; }
        [JsonProperty("releaseYear")]
        public DateTime? ReleaseYear { get; set; }
        [JsonProperty("consumptionRate")]
        public decimal? ConsumptionRate { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
