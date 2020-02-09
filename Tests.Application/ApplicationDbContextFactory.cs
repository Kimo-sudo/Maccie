using System;
using Domain.Entities;
using Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Tests.Application
{

        public static class ApplicationDbContextFactory
        {
            public static ApplicationDbContext Create()
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                var context = new ApplicationDbContext(
                    options);

                context.Database.EnsureCreated();

                SeedSampleData(context);

                return context;
            }

            public static void SeedSampleData(ApplicationDbContext context)
            {
                context.Bestellingen.AddRange(
                    new Order
                        { 
                            OrderId = 1, 
                            KeukenAfgerond = false,
                        }
                );

                context.BesteldeProducten.AddRange(
                    new BesteldProduct() { Id = 1, Hoeveelheid = 1, OrderId = 1, ProductId = 1 },
                    new BesteldProduct() { Id = 4, Hoeveelheid = 3, OrderId = 1, ProductId = 1 }
                );
                context.Categories.AddRange(
                    new Categorie
                    {
                        CategorieId = 1,
                        CategorieNaam = "Burgers"
                    }
                );
                context.Producten.AddRange(
                    new Product
                    {
                        Id = 1,
                        CategorieId = 1,
                        Prijs = 2.84,
                        ProductName = "BigMac"
                    }
                );

            context.SaveChanges();
            }
            public static void Destroy(ApplicationDbContext context)
            {
                context.Database.EnsureDeleted();

                context.Dispose();
            }
        }
    }
