using Microsoft.EntityFrameworkCore;
using Shop.Persistance.Contexts;
using Shop.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Persistance.DataSeeders
{
    public class DataSeeder
    {
        public static void SeedCountries(ShopContext context)
        {
            if (!context.Countries.Any())
            {
                var entities = new List<Country>
            {
                new Country { Name = "Afghanistan" },
                new Country { Name = "Albania" },
                new Country { Name = "Algeria" },
                new Country { Name = "Andorra" },
                new Country { Name = "Angola" },
                new Country { Name = "Antigua and Barbuda" },
                new Country { Name = "Argentina" },
                new Country { Name = "Armenia" },
                new Country { Name = "Aruba" },
                new Country { Name = "Australia" },
                new Country { Name = "Austria" },
                new Country { Name = "Azerbaijan" },
            };
                context.AddRange(entities);
                context.SaveChanges();
            }
        }
        public static void SeedColors(ShopContext context)
        {
            if (!context.Colors.Any())
            {
                var entities = new List<Color>
            {
                new Color { Name = "Afghanistan" },
                new Color { Name = "Albania" },
                new Color { Name = "Algeria" },
                new Color { Name = "Andorra" },
                new Color { Name = "Angola" },
                
            };
                context.AddRange(entities);
                context.SaveChanges();
            }
        }
        public static void SeedConservations(ShopContext context)
        {
            if (!context.Conservations.Any())
            {
                var entities = new List<Conservation>
            {
                new Conservation { Name = "Afghanistan" },
                new Conservation { Name = "Albania" },
                new Conservation { Name = "Algeria" },
                new Conservation { Name = "Andorra" },
                new Conservation { Name = "Angola" },
                new Conservation { Name = "Antigua and Barbuda" },
                new Conservation { Name = "Argentina" },
                new Conservation { Name = "Armenia" },
                new Conservation { Name = "Aruba" },
                new Conservation { Name = "Australia" },
                new Conservation { Name = "Austria" },
                new Conservation { Name = "Azerbaijan" },
            };
                context.AddRange(entities);
                context.SaveChanges();
            }
        }
        public static void SeedCategories(ShopContext context)
        {
            if (!context.Categories.Any())
            {
                var entities = new List<Category>
            {
                new Category { Name = "Afghanistan" },
                new Category { Name = "Albania" },
                new Category { Name = "Algeria" },
                new Category { Name = "Andorra" },
                new Category { Name = "Angola" },
                new Category { Name = "Antigua and Barbuda" },
                new Category { Name = "Argentina" },
                new Category { Name = "Armenia" },
                new Category { Name = "Aruba" },
                new Category { Name = "Australia" },
                new Category { Name = "Austria" },
                new Category { Name = "Azerbaijan" },
            };
                context.AddRange(entities);
                context.SaveChanges();
            }
        }
        public static void SeedOriginalities(ShopContext context)
        {
            if (!context.Originalities.Any())
            {
                var entities = new List<Originality>
            {
                new Originality { Name = "Afghanistan" },
                new Originality { Name = "Albania" },
                new Originality { Name = "Algeria" },
                new Originality { Name = "Andorra" },
                new Originality { Name = "Angola" },
                new Originality { Name = "Antigua and Barbuda" },
                new Originality { Name = "Argentina" },
                new Originality { Name = "Armenia" },
                new Originality { Name = "Aruba" },
                new Originality { Name = "Australia" },
                new Originality { Name = "Austria" },
                new Originality { Name = "Azerbaijan" },
            };
                context.AddRange(entities);
                context.SaveChanges();
            }
        }
        public static void SeedRegions(ShopContext context)
        {
            if (!context.Regions.Any())
            {
                var entities = new List<Region>
            {
                new Region { Name = "Afghanistan" },
                new Region { Name = "Albania" },
                new Region { Name = "Algeria" },
                new Region { Name = "Andorra" },
                new Region { Name = "Angola" },
                new Region { Name = "Antigua and Barbuda" },
                new Region { Name = "Argentina" },
                new Region { Name = "Armenia" },
                new Region { Name = "Aruba" },
                new Region { Name = "Australia" },
                new Region { Name = "Austria" },
                new Region { Name = "Azerbaijan" },
            };
                context.AddRange(entities);
                context.SaveChanges();
            }
        }
        public static void SeedTastes(ShopContext context)
        {
            if (!context.Tastes.Any())
            {
                var entities = new List<Taste>
            {
                new Taste { Name = "Afghanistan" },
                new Taste { Name = "Albania" },
                new Taste { Name = "Algeria" },
                new Taste { Name = "Andorra" },
                new Taste { Name = "Angola" },
                new Taste { Name = "Antigua and Barbuda" },
                new Taste { Name = "Argentina" },
                new Taste { Name = "Armenia" },
                new Taste { Name = "Aruba" },
                new Taste { Name = "Australia" },
                new Taste { Name = "Austria" },
                new Taste { Name = "Azerbaijan" },
            };
                context.AddRange(entities);
                context.SaveChanges();
            }
        }
        public static void SeedVintages(ShopContext context)
        {
            if (!context.Vintages.Any())
            {
                var entities = new List<Vintage>
            {
                new Vintage { Name = "Afghanistan" },
                new Vintage { Name = "Albania" },
                new Vintage { Name = "Algeria" },
                new Vintage { Name = "Andorra" },
                new Vintage { Name = "Angola" },
                new Vintage { Name = "Antigua and Barbuda" },
                new Vintage { Name = "Argentina" },
                new Vintage { Name = "Armenia" },
                new Vintage { Name = "Aruba" },
                new Vintage { Name = "Australia" },
                new Vintage { Name = "Austria" },
                new Vintage { Name = "Azerbaijan" },
            };
                context.AddRange(entities);
                context.SaveChanges();
            }
        }
        public static void SeedVolumes(ShopContext context)
        {
            if (!context.Countries.Any())
            {
                var entities = new List<Volume>
            {
                new Volume { Name = "Afghanistan" },
                new Volume { Name = "Albania" },
                new Volume { Name = "Algeria" },
                new Volume { Name = "Andorra" },
                new Volume { Name = "Angola" },
                new Volume { Name = "Antigua and Barbuda" },
                new Volume { Name = "Argentina" },
                new Volume { Name = "Armenia" },
                new Volume { Name = "Aruba" },
                new Volume { Name = "Australia" },
                new Volume { Name = "Austria" },
                new Volume { Name = "Azerbaijan" },
            };
                context.AddRange(entities);
                context.SaveChanges();
            }
        }
    }
}
