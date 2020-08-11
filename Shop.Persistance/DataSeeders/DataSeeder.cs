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
                new Country { Name = "France" },
                new Country { Name = "Maroc" },
                new Country { Name = "Italie" },
                new Country { Name = "Portugal" },
                new Country { Name = "Espagne" },
                new Country { Name = "Autre" },
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
                new Color { Name = "Blanc" },
                new Color { Name = "Jaune" },
                new Color { Name = "Rouge" },
                new Color { Name = "Rosé" },
                new Color { Name = "Gris" },
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
                new Conservation { Name = "Prêt à boire" },
                new Conservation { Name = "Peut être conservé" },
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
                new Category { Name = "Vin" },
                new Category { Name = "Champagnes" },
                new Category { Name = "Spiritueux" },
                new Category { Name = "Bières" },
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
                new Originality { Name = "importées" },
                new Originality { Name = "locales" },
                new Originality { Name = "étrangères" },
               
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
                new Region { Name = "Bourgogne" },
                new Region { Name = "Loire et Centre" },
                new Region { Name = "Bordeaux" },
                new Region { Name = "Provence" },
                new Region { Name = "Languedoc-Roussillon" },
                new Region { Name = "Rhône" },
                new Region { Name = "Ouled Thaleb" },
                new Region { Name = "Sud-Ouest" },
                new Region { Name = "Meknès" },
                new Region { Name = "Côtes du Rhône" },
                new Region { Name = "Autre" },
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
                new Taste { Name = "Fruité et plein" },
                new Taste { Name = "Fruité et souple" },
                new Taste { Name = "Fruité et nerveux" },
                new Taste { Name = "Bouqueté et à la reserve" },
                new Taste { Name = "Bouqueté et souple" },
                new Taste { Name = "Bouqueté corse et à point" },
                new Taste { Name = "Bouqueté et corsé à point" },
                new Taste { Name = "Fruité et soyeux" },
                new Taste { Name = "Rond et bouqueté" },
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
                new Vintage { Name = "2010" },
                new Vintage { Name = "2011" },
                new Vintage { Name = "2012" },
                new Vintage { Name = "2013" },
                new Vintage { Name = "2014" },
                new Vintage { Name = "2015" },
                new Vintage { Name = "2016" },
                new Vintage { Name = "2017" },
                new Vintage { Name = "2018" },
                new Vintage { Name = "2019" },
                new Vintage { Name = "2020" },
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
                new Volume { Name = "20" },
                new Volume { Name = "25" },
                new Volume { Name = "27" },
                new Volume { Name = "33" },
                new Volume { Name = "35" },
                new Volume { Name = "37" },
                new Volume { Name = "50" },
                new Volume { Name = "70" },
                new Volume { Name = "75" },
                new Volume { Name = "100" },
                new Volume { Name = "150" },
                new Volume { Name = "175" },
                
                
            };
                context.AddRange(entities);
                context.SaveChanges();
            }
        }
    }
}
