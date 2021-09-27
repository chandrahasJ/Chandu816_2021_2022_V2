using BRHomeWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BRHomeWebApi.DataC
{
    public class BRHomeDbContext : DbContext
    {
        public BRHomeDbContext(DbContextOptions<BRHomeDbContext> options) : base(options)
        {
            
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<FurnishingType> FurnishingTypes { get; set; }
    }
}