﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Shop.Application.Domains
{
    public partial class PanierModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int NbrProduct { get; set; }
        public decimal TotalAmount { get; set; }
        public int? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}