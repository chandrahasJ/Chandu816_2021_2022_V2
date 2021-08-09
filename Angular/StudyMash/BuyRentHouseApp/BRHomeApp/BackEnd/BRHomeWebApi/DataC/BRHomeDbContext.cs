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
    }
}