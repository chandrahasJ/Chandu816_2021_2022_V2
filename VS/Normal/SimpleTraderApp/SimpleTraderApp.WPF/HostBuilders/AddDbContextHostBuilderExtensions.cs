using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTraderApp.EFCore;
using SimpleTraderApp.WPF.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                SecretManagerClass.Build();

                Action<DbContextOptionsBuilder> configureDbContext = x => x.UseSqlServer(SecretManagerClass.myConnectionStrings.SqlConnectionString);
                services.AddDbContext<SimpleTraderAppDbContext>(configureDbContext);
                services.AddSingleton<SimpleTraderAppDbContextFactory>(new SimpleTraderAppDbContextFactory(configureDbContext));
            });
            return host;
        }
    }
}
