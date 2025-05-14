using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Models;

namespace AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = new ApplicationDbContext(
               serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            var product = new Product
            {
                Name = "Sample Product",
                ProductionDate = DateTime.Now 
            };
            if (context.Farmers.Any()) return; // DB already seeded

            var farmers = new[]
            {
                    new Farmer { Name = "Thabo Mokoena", Email = "thabo@farmconnect.co.za", ContactNumber = "0821234567" },
                    new Farmer { Name = "Zanele Ndlovu", Email = "zanele@greenfarm.org", ContactNumber = "0739876543" }
                };

            context.Farmers.AddRange(farmers);
            context.SaveChanges();

            var products = new[]
            {
                    new Product { Name = "Maize", Category = "Grain", ProductionDate = DateTime.Parse("2024-11-01"), FarmerID = farmers[0].FarmerID.ToString() },
                    new Product { Name = "Tomatoes", Category = "Vegetables", ProductionDate = DateTime.Parse("2024-12-15"), FarmerID = farmers[1].FarmerID.ToString() }
                };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
