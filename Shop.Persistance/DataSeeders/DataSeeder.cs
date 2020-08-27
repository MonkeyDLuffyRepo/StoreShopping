using Microsoft.EntityFrameworkCore;
using Shop.Persistance.Contexts;
using Shop.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Shop.Persistance.DataSeeders
{
    public class DataSeeder
    {
        public static void SeedData(ShopContext context)
        {
            SeedCustomers(context);
            SeedCountries(context);
            SeedColors(context);
            SeedConservations(context);
            SeedConservations(context);
            SeedCategories(context);
            SeedOriginalities(context);
            SeedTastes(context);
            SeedVintages(context);
            SeedVolumes(context);

        }
        public static void SeedCustomers(ShopContext context)
        {
            if (!context.Customers.Any())
            {
                var entities = new List<Customer>
            {
                new Customer { 
                    FirstName = "Mohammed", LastName = "Ed-daou", UserName="eddaou.med", 
                    Password = "password",Email = "eddaou.med@gmail.com",Birthday = new DateTime(1991,02,19),
                    City = "Casablanca", Address = "51 rue attabari",Phone = "0625206679", CreationDate = DateTime.Now

                },
                new Customer {
                    FirstName = "Saiid", LastName = "Messaoudi", UserName="saiid.mess",
                    Password = "password",Email = "saiid.mess@gmail.com",Birthday = new DateTime(1991,06,29),
                    City = "Casablanca", Address = "55 rue nearshore",Phone = "0625206679", CreationDate = DateTime.Now

                } 
            };
                context.AddRange(entities);
                context.SaveChanges();
            }
        }
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
                new Volume { Name = "20 cl" },
                new Volume { Name = "25 cl" },
                new Volume { Name = "27 cl" },
                new Volume { Name = "33 cl" },
                new Volume { Name = "35 cl" },
                new Volume { Name = "37 cl" },
                new Volume { Name = "50 cl" },
                new Volume { Name = "70 cl" },
                new Volume { Name = "75 cl" },
                new Volume { Name = "100 cl" },
                new Volume { Name = "150 cl" },
                new Volume { Name = "175 cl" },
                
                
            };
                context.AddRange(entities);
                context.SaveChanges();
            }
        }
    }
}
