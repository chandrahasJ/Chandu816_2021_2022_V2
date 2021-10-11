    using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.Domain.Services.AuthServices;
using SimpleTraderApp.Domain.Services.TransactionServices;
using SimpleTraderApp.EFCore;
using SimpleTraderApp.EFCore.Services;
using SimpleTraderApp.FMPrepAPI.Services;
using SimpleTraderApp.WPF.Configurations;
using SimpleTraderApp.WPF.State.Accounts;
using SimpleTraderApp.WPF.State.Assets;
using SimpleTraderApp.WPF.State.Authenticators;
using SimpleTraderApp.WPF.State.Navigators;
using SimpleTraderApp.WPF.ViewModels;
using SimpleTraderApp.WPF.ViewModels.Factories;
using System;
using System.Windows;
using Microsoft.Extensions ;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using SimpleTraderApp.WPF.HostBuilders;

namespace SimpleTraderApp.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                        .AddConfigurations()
                        .AddDbContext()
                        .AddServices()
                        .AddStores()
                        .AddViewModels()
                        .AddViews();                                            
        }

        protected  override async  void OnStartup(StartupEventArgs e)
        {
           await  _host.StartAsync();

            IServiceProvider serviceProvider = _host.Services;

            SimpleTraderAppDbContextFactory contextFactory = serviceProvider.GetRequiredService<SimpleTraderAppDbContextFactory>();
            using (SimpleTraderAppDbContext traderAppDbContext = contextFactory.CreateDbContext())
            {
                traderAppDbContext.Database.Migrate();
            }


            Window window  = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
           await _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
