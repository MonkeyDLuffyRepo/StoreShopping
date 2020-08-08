using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.API.Domains.PositionModels
{
    public partial class PositionModel
    {
        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }
        [JsonProperty("vehiculeId")]
        public int VehiculeId { get; set; }
        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }
        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }
        [JsonProperty("speed")]
        public decimal? Speed { get; set; }
    }
}
