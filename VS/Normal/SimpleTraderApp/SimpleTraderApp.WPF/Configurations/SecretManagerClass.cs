using Microsoft.Extensions.Configuration;
using SimpleTraderApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleTraderApp.WPF.Configurations
{
    /// <summary>
    /// Code Taken from below website
    /// https://ballardsoftware.com/adding-appsettings-json-configuration-to-a-net-core-console-application/
    /// </summary>
    public class SecretManagerClass 
    {
        private SecretManagerClass()
        {

        }

        public static MySettingConfiguration mySettingConfiguration { get; set; }

        public static void Build()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets<MainWindow>()
                .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();
            mySettingConfiguration = new MySettingConfiguration();
            configuration.GetSection("MySettings").Bind(mySettingConfiguration);

        }
    }
}
