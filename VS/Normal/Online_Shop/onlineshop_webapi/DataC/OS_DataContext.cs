using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using onlineshop_webapi.Models;

namespace onlineshop_webapi.DataC
{
    public class OS_DataContext : DbContext
    {
        public OS_DataContext(DbContextOptions<OS_DataContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }
}