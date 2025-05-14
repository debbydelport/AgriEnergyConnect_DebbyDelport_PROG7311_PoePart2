using Microsoft.EntityFrameworkCore;
using AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Models;

namespace AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            // Exit if already populated
            if (context.Farmers.Any() || context.Products.Any())
                return;

            // Populate Farmers
            var farmers = new[]
            {
                new Farmer { Name = "Thabo Mokoena", Email = "thabo@farmconnect.co.za", ContactNumber = "0821234567" },
                new Farmer { Name = "Zanele Ndlovu", Email = "zanele@greenfarm.org", ContactNumber = "0739876543" }
            };

            context.Farmers.AddRange(farmers);
            context.SaveChanges(); 

            // Populate Products
            var products = new[]
            {
                new Product
                {
                    Name = "Maize",
                    Category = "Grain",
                    ProductionDate = DateTime.Parse("2024-11-01"),
                    Description = "High-quality white maize",
                    FarmerID = farmers[0].FarmerID.ToString(),
                    FarmerID1 = farmers[0].FarmerID,
                    Price = 150.00M
                },
                new Product
                {
                    Name = "Tomatoes",
                    Category = "Vegetables",
                    ProductionDate = DateTime.Parse("2024-12-15"),
                    Description = "Fresh and juicy tomatoes",
                    FarmerID = farmers[1].FarmerID.ToString(),
                    FarmerID1 = farmers[1].FarmerID,
                    Price = 60.00M
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
