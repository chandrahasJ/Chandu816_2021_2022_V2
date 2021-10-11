using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.Domain.Services.AuthServices;
using SimpleTraderApp.Domain.Services.TransactionServices;
using SimpleTraderApp.EFCore.Services;
using SimpleTraderApp.FMPrepAPI.Services;
using SimpleTraderApp.WPF.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.HostBuilders
{
    public static class AddServicesBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IDataService<Account>, AccountDataService>();
                services.AddSingleton<IAccountService, AccountDataService>();
                services.AddSingleton<IAuthenticationService, AuthenticationService>();
                services.AddSingleton<IStockPriceService>(x => new StockPriceService(SecretManagerClass.mySettingConfiguration.FMPApiKey));
                services.AddSingleton<IBuyStockService, BuyStockService>();
                services.AddSingleton<ISellStockService, SellStockService>();
                services.AddSingleton<IMajorIndexService>(x => new MajorIndexService(SecretManagerClass.mySettingConfiguration.FMPApiKey));

                services.AddSingleton<IPasswordHasher, PasswordHasher>();
            });
            return host;
        }
    }
}
