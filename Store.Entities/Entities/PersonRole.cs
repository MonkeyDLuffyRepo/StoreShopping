﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Store.Persistance.Entities
{
      
    public partial class PersonRole : EntityBase
    {
        public long PersonId { get; set; }
        public int RoleId { get; set; }
        public DateTime? ModiicationDate { get; set; }
        public bool? Active { get; set; }

        public virtual Person Person { get; set; }
        public virtual Role Role { get; set; }
    }
}