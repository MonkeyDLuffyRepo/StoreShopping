﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Store.Persistance.Entities
{
    public partial class Vehicule
    {
        public Vehicule()
        {
            PersonVehicules = new HashSet<PersonVehicule>();
            Positions = new HashSet<Position>();
        }
      
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Name { get; set; }
        public int CapacitySeat { get; set; }
        public int? AvailableSeat { get; set; }
        public int? PersonId { get; set; }
        public int? TypeId { get; set; }
        public string Model { get; set; }
        public string Mark { get; set; }
        public DateTime? ReleaseYear { get; set; }
        public decimal? ConsumptionRate { get; set; }
        public string Description { get; set; }

        public virtual VehiculeType Type { get; set; }
        public virtual ICollection<PersonVehicule> PersonVehicules { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
    }
}