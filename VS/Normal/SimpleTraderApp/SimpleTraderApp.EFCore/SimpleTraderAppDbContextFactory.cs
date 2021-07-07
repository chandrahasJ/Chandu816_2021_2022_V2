using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.EFCore
{
    public class SimpleTraderAppDbContextFactory : IDesignTimeDbContextFactory<SimpleTraderAppDbContext>
    {
        public SimpleTraderAppDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SimpleTraderAppDbContext>();
            options.UseSqlServer("Data Source=DESKTOP-OAI7BIC;Initial Catalog=SimpleTraderDB;Integrated Security=True;");

            return new SimpleTraderAppDbContext(options.Options);
        }
    }
}
