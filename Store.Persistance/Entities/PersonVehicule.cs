﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Store.Persistance.Entities
{
    public partial class PersonVehicule
    {
        public int PersonId { get; set; }
        public int VehiculeId { get; set; }
        public int RoleId { get; set; }

        public virtual Person Person { get; set; }
        public virtual PersonRole Role { get; set; }
        public virtual Vehicule Vehicule { get; set; }
    }
}