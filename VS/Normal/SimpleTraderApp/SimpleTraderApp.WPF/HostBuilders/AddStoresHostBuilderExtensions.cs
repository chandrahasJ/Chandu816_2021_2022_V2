using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTraderApp.WPF.State.Accounts;
using SimpleTraderApp.WPF.State.Assets;
using SimpleTraderApp.WPF.State.Authenticators;
using SimpleTraderApp.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.HostBuilders
{
    public static class AddStoresHostBuilderExtensions
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<IAuthenticator, Authenticator>();
                services.AddSingleton<IAccountStore, AccountStore>();
                services.AddSingleton<AssetStore>();
            });

            return host;
        }
    }
}
