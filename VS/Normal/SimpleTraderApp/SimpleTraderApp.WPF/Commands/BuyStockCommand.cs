using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services.TransactionServices;
using SimpleTraderApp.WPF.State.Accounts;
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
        private readonly IAccountStore _accountStore;

        public event EventHandler CanExecuteChanged;
        public BuyStockCommand(BuyViewModel buyViewModel, IBuyStockService buyStockService, IAccountStore accountStore)
        {
            this._buyViewModel = buyViewModel;
            this._buyStockService = buyStockService;
            this._accountStore = accountStore;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                if (_buyViewModel.SharesToBuy == 0)
                {
                    return;
                }

                Account account = await _buyStockService.BuyStock(this._accountStore.CurrentAccount,
                _buyViewModel.Symbol,
                _buyViewModel.SharesToBuy
                );

                _accountStore.CurrentAccount = account;

                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
