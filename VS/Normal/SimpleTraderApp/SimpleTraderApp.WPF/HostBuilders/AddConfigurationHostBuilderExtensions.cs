using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTraderApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.HostBuilders
{
    public static class AddConfigurationHostBuilderExtensions
    {
        public static IHostBuilder AddConfigurations(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration(c =>
            {
                c.AddJsonFile("appSettings.json");
            });
            return host;
        }
    }
}
