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
                      .ConfigureAppConfiguration(c => {
                          c.AddJsonFile("appSettings.json");
                      })
                     .ConfigureServices((context, services) => {
                         SecretManagerClass.Build();

                         services.AddDbContext<SimpleTraderAppDbContext>(x => x.UseSqlServer(SecretManagerClass.myConnectionStrings.SqlConnectionString));
                         services.AddSingleton<SimpleTraderAppDbContextFactory>(new SimpleTraderAppDbContextFactory(SecretManagerClass.myConnectionStrings.SqlConnectionString));
                         services.AddSingleton<IDataService<Account>, AccountDataService>();
                         services.AddSingleton<IAccountService, AccountDataService>();
                         services.AddSingleton<IAuthenticationService, AuthenticationService>();
                         services.AddSingleton<IStockPriceService>(x => new StockPriceService(SecretManagerClass.mySettingConfiguration.FMPApiKey));
                         services.AddSingleton<IBuyStockService, BuyStockService>();
                         services.AddSingleton<ISellStockService, SellStockService>();
                         services.AddSingleton<IMajorIndexService>(x => new MajorIndexService(SecretManagerClass.mySettingConfiguration.FMPApiKey));

                         services.AddSingleton<IPasswordHasher, PasswordHasher>();

                         services.AddSingleton<ISimpleTradeViewModelFactory, SimpleTradeViewModelFactory>();
                         services.AddSingleton<ViewModelDelegateReNavigator<HomeViewModel>>();
                         services.AddSingleton<ViewModelDelegateReNavigator<RegisterViewModel>>();
                         services.AddSingleton<ViewModelDelegateReNavigator<LoginViewModel>>();
                         services.AddSingleton<BuyViewModel>();
                         services.AddSingleton<PortfolioViewModel>();
                         services.AddSingleton<AssetSummaryViewModel>();
                         services.AddSingleton<HomeViewModel>(services =>
                               new HomeViewModel(
                                     services.GetRequiredService<AssetSummaryViewModel>(),
                                     MajorIndexListingViewModel.LoadMajorIndexViewModel(services.GetRequiredService<IMajorIndexService>()
                                 ))
                         );


                         //Adding ViewModels to DI
                         services.AddSingleton<CreateViewModel<LoginViewModel>>(services => {
                             return () => new LoginViewModel(
                                     services.GetRequiredService<IAuthenticator>(),
                                     services.GetRequiredService<ViewModelDelegateReNavigator<HomeViewModel>>(),
                                     services.GetRequiredService<ViewModelDelegateReNavigator<RegisterViewModel>>()
                                 );
                         });

                         services.AddSingleton<CreateViewModel<HomeViewModel>>(services => {
                             return () => services.GetRequiredService<HomeViewModel>();
                         });

                         services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => {
                             return () => new RegisterViewModel(
                                     services.GetRequiredService<IAuthenticator>(),
                                     services.GetRequiredService<ViewModelDelegateReNavigator<LoginViewModel>>(),
                                     services.GetRequiredService<ViewModelDelegateReNavigator<LoginViewModel>>()
                                 );
                         });

                         services.AddSingleton<CreateViewModel<PortfolioViewModel>>(services => {
                             return () => services.GetRequiredService<PortfolioViewModel>();
                         });

                         services.AddSingleton<CreateViewModel<BuyViewModel>>(services => {
                             return () => services.GetRequiredService<BuyViewModel>();
                         });

                         services.AddSingleton<INavigator, Navigator>();
                         services.AddSingleton<IAuthenticator, Authenticator>();
                         services.AddSingleton<IAccountStore, AccountStore>();
                         services.AddSingleton<AssetStore>();
                         services.AddScoped<MainViewModel>();

                         services.AddScoped<MainWindow>(x => new MainWindow(x.GetRequiredService<MainViewModel>()));

                     });
        }

        protected  override async  void OnStartup(StartupEventArgs e)
        {
           await  _host.StartAsync();

            IServiceProvider serviceProvider = _host.Services;


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
