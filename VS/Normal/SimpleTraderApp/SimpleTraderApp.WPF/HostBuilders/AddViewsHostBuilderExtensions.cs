using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTraderApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.HostBuilders
{
    public static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {

                services.AddSingleton<MainWindow>(x => new MainWindow(x.GetRequiredService<MainViewModel>()));
            });
            return host;
        }
    }
}
