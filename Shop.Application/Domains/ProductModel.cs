﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Shop.Application.Domains
{
    public partial class ProductModel
    {
        
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public decimal? Price { get; set; }
        public int? AvailableStock { get; set; }
        public string PicturesPath { get; set; }
        public int? ColorId { get; set; }
        public int? VintageId { get; set; }
        public int? OriginalityId { get; set; }
        public int? RegionId { get; set; }
        public int? CountryId { get; set; }
        public int? VolumeId { get; set; }
        public int? TasteId { get; set; }
        public int? ConservationId { get; set; }

    }

    public enum RelatedProductDataEnum
    {
        CATEGORY = 0,
        COLOR=1,
        VINTAGE=2,
        ORINALITY=3,
        REGION=4,
        COUNTRY=5,
        VOLUME=6,
        TASTE=7,
        CONSERVATION=8,
        OTHER=9
    }
}