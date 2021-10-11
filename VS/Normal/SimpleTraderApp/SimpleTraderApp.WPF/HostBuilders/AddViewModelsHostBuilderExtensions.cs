using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.WPF.State.Authenticators;
using SimpleTraderApp.WPF.State.Navigators;
using SimpleTraderApp.WPF.ViewModels;
using SimpleTraderApp.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) => {

                services.AddSingleton<ISimpleTradeViewModelFactory, SimpleTradeViewModelFactory>();
                services.AddSingleton<ViewModelDelegateReNavigator<HomeViewModel>>();
                services.AddSingleton<ViewModelDelegateReNavigator<RegisterViewModel>>();
                services.AddSingleton<ViewModelDelegateReNavigator<LoginViewModel>>();
                services.AddSingleton<BuyViewModel>();
                services.AddSingleton<SellViewModel>();
                services.AddSingleton<PortfolioViewModel>();
                services.AddSingleton<AssetSummaryViewModel>();
                services.AddSingleton<MainViewModel>();

                services.AddSingleton<HomeViewModel>(CreateHomeViewModel);

                //Adding ViewModels to DI
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));

                services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => services.GetRequiredService<HomeViewModel>());

                services.AddSingleton<CreateViewModel<RegisterViewModel>>(services =>  () => CreateRegisterViewModel(services));

                services.AddSingleton<CreateViewModel<PortfolioViewModel>>(services =>  () => services.GetRequiredService<PortfolioViewModel>());

                services.AddSingleton<CreateViewModel<BuyViewModel>>(services => () => services.GetRequiredService<BuyViewModel>());

                services.AddSingleton<CreateViewModel<SellViewModel>>(services => () => services.GetRequiredService<SellViewModel>());

            });

            return host;
        }

        private static HomeViewModel CreateHomeViewModel(IServiceProvider services)
        {
            return new HomeViewModel(
                            services.GetRequiredService<AssetSummaryViewModel>(),
                            MajorIndexListingViewModel.LoadMajorIndexViewModel(services.GetRequiredService<IMajorIndexService>()
                        ));
             
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        {
            return  new LoginViewModel(
                           services.GetRequiredService<IAuthenticator>(),
                           services.GetRequiredService<ViewModelDelegateReNavigator<HomeViewModel>>(),
                           services.GetRequiredService<ViewModelDelegateReNavigator<RegisterViewModel>>()
                       );
        }

        private static RegisterViewModel CreateRegisterViewModel(IServiceProvider services)
        {
            return new   RegisterViewModel(
                            services.GetRequiredService<IAuthenticator>(),
                            services.GetRequiredService<ViewModelDelegateReNavigator<LoginViewModel>>(),
                            services.GetRequiredService<ViewModelDelegateReNavigator<LoginViewModel>>()
                        );
        }
    }
}
