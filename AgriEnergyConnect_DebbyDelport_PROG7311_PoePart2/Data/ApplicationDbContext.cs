using Microsoft.EntityFrameworkCore;
using AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Models;
using Microsoft.AspNetCore.Identity;

namespace AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Farmer> Farmers { get; set; } // Add this line
        public DbSet<Product> Products { get; set; } // Ensure this exists for Products
    }
}
