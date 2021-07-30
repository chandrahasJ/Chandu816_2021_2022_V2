using Microsoft.Extensions.DependencyInjection;
using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.Domain.Services.TransactionServices;
using SimpleTraderApp.EFCore;
using SimpleTraderApp.EFCore.Services;
using SimpleTraderApp.FMPrepAPI.Services;
using SimpleTraderApp.WPF.Configurations;
using SimpleTraderApp.WPF.State.Navigators;
using SimpleTraderApp.WPF.ViewModels;
using SimpleTraderApp.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleTraderApp.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            

            IServiceProvider serviceProvider = CreateServiceProvider();
            IBuyStockService buyStockService = serviceProvider.GetRequiredService<IBuyStockService>();

            Window window  = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();


            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            SecretManagerClass.Build();


            services.AddSingleton<SimpleTraderAppDbContextFactory>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<IStockPriceService>(x => new StockPriceService(SecretManagerClass.mySettingConfiguration.FMPApiKey));
            services.AddSingleton<IBuyStockService, BuyStockService>();
            services.AddSingleton<IMajorIndexService>(x => new MajorIndexService(SecretManagerClass.mySettingConfiguration.FMPApiKey));

            services.AddSingleton< ISimpleTradeViewModelAbstractFactory,SimpleTradeViewModelAbstractFactory >();

            services.AddSingleton<ISimpleTraderViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<PortfolioViewModel>, PortfolioViewModelFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<MajorIndexListingViewModel>, MajorIndexListingViewModelFactory>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(x => new MainWindow(x.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();           
        }
    }
}
