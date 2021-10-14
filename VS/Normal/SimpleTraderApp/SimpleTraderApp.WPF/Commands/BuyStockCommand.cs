using SimpleTraderApp.Domain.Exceptions;
using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services.TransactionServices;
using SimpleTraderApp.WPF.State.Accounts;
using SimpleTraderApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.Commands
{
    public class BuyStockCommand : AsyncCommandBase
    {
        private readonly BuyViewModel _buyViewModel;
        private readonly IBuyStockService _buyStockService;
        private readonly IAccountStore _accountStore;

        public BuyStockCommand(BuyViewModel buyViewModel, IBuyStockService buyStockService, IAccountStore accountStore)
        {
            this._buyViewModel = buyViewModel;
            this._buyStockService = buyStockService;
            this._accountStore = accountStore;

            this._buyViewModel.PropertyChanged += _buyViewModel_PropertyChanged;
        }

        private void _buyViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BuyViewModel.CanBuyStock))
            {
                OnCanExecuteChanged();
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _buyViewModel.StatusMessage = String.Empty;
            _buyViewModel.ErrorMessage = String.Empty;
            string Symbol = _buyViewModel.Symbol;
            int SharesToBuy = _buyViewModel.SharesToBuy;
            try
            {
                if (SharesToBuy == 0)
                {
                    return;
                }


                Account account = await _buyStockService.BuyStock(this._accountStore.CurrentAccount,
                Symbol,
                SharesToBuy
                );

                _accountStore.CurrentAccount = account;

                _buyViewModel.StatusMessage = $"Successfully purchased {SharesToBuy} shares of {Symbol}.";
            }
            catch (InvalidSymbolException)
            {
                _buyViewModel.ErrorMessage = "Symbol does not exists.";
            }
            catch (InsufficentFundExpection)
            {
                _buyViewModel.ErrorMessage = "Account has insufficent funds. Please transfer more money into your account.";
            }
            catch (Exception)
            {
                _buyViewModel.ErrorMessage = "Transaction Failed.";
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _buyViewModel.CanBuyStock && base.CanExecute(parameter);
        }
    }
}
