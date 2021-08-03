using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services.TransactionServices;
using SimpleTraderApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.Commands
{
    public class BuyStockCommand : ICommand
    {
        private readonly BuyViewModel _buyViewModel;
        private readonly IBuyStockService _buyStockService;

        public event EventHandler CanExecuteChanged;
        public BuyStockCommand(BuyViewModel buyViewModel, IBuyStockService buyStockService)
        {
            this._buyViewModel = buyViewModel;
            this._buyStockService = buyStockService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                Account account = await _buyStockService.BuyStock(new Account()
                {
                    Id = 1,
                    Balance = 500,
                    AssetTrasactions = new List<AssetTransaction>()
                },
                _buyViewModel.Symbol,
                _buyViewModel.SharesToBuy
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
