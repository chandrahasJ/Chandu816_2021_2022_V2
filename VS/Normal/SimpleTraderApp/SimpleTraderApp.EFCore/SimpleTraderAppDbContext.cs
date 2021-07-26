using Microsoft.EntityFrameworkCore;
using SimpleTraderApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.EFCore
{
    public class SimpleTraderAppDbContext : DbContext
    {
        public SimpleTraderAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransaction> AssetTrasactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Asset);
            base.OnModelCreating(modelBuilder);
        }
    }
}
