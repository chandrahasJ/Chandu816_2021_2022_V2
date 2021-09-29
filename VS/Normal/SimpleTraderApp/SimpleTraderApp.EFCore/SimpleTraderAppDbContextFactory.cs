using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.EFCore
{
    public class SimpleTraderAppDbContextFactory 
    {        
        
        private readonly Action<DbContextOptionsBuilder> configureDbContext;

        public SimpleTraderAppDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {

            this.configureDbContext = configureDbContext;
        }

        public SimpleTraderAppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<SimpleTraderAppDbContext>();
            configureDbContext(options);

            return new SimpleTraderAppDbContext(options.Options);
        }
    }
}
