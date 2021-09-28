using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.EFCore
{
    public class SimpleTraderAppDbContextFactory 
    {
        private readonly string connectionString;

        public SimpleTraderAppDbContextFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SimpleTraderAppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<SimpleTraderAppDbContext>();
            options.UseSqlServer(this.connectionString);

            return new SimpleTraderAppDbContext(options.Options);
        }
    }
}
