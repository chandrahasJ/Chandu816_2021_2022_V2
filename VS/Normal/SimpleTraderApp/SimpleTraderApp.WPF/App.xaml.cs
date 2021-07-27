using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.Domain.Services.TransactionServices;
using SimpleTraderApp.EFCore.Services;
using SimpleTraderApp.FMPrepAPI.Services;
using SimpleTraderApp.WPF.Configurations;
using SimpleTraderApp.WPF.ViewModels;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = new MainWindow();
            SecretManagerClass.Build();

            IStockPriceService stockPriceService = new StockPriceService(SecretManagerClass.mySettingConfiguration.FMPApiKey);
            IDataService<Account> accountServices = new GenericDataService<Account>(new EFCore.SimpleTraderAppDbContextFactory());
            IBuyStockService buyStockService = new BuyStockService(stockPriceService, accountServices);


            


            window.DataContext = new MainViewModel();
            window.Show();

            base.OnStartup(e);
        }
    }
}
