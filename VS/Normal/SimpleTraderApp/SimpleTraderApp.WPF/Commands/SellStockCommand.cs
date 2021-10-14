using SimpleTraderApp.Domain.Exceptions;
using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services.TransactionServices;
using SimpleTraderApp.WPF.State.Accounts;
using SimpleTraderApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.WPF.Commands
{
    public class SellStockCommand : AsyncCommandBase
    {
        private readonly SellViewModel _sellViewModel;
        private readonly ISellStockService _sellStockService;
        private readonly IAccountStore _accountStore;

        public SellStockCommand(SellViewModel sellViewModel, ISellStockService sellStockService, IAccountStore accountStore)
        {
            this._sellViewModel = sellViewModel;
            this._sellStockService = sellStockService;
            this._accountStore = accountStore;

            _sellViewModel.PropertyChanged += _sellViewModel_PropertyChanged;
        }

        private void _sellViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SellViewModel.CanSellStock))
            {
                OnCanExecuteChanged();
            }
        }

        public override  async Task ExecuteAsync(object parameter)
        {
            _sellViewModel.StatusMessage = String.Empty;
            _sellViewModel.ErrorMessage = String.Empty;
            string Symbol = _sellViewModel.Symbol;
            int SharesToSell = _sellViewModel.SharesToSell;
            try
            {
                if (SharesToSell == 0)
                {
                    return;
                }


                Account account = await _sellStockService.SellStock(this._accountStore.CurrentAccount,
                Symbol,
                SharesToSell
                );

                _accountStore.CurrentAccount = account;

                _sellViewModel.StatusMessage = $"Successfully sold {SharesToSell} shares of {Symbol}.";
                _sellViewModel.SearchResultSymbol = String.Empty;
            }
            catch (InvalidSymbolException)
            {
                _sellViewModel.ErrorMessage = "Symbol does not exists.";
            }
            catch (InsufficentSharesExpection e)
            {
                _sellViewModel.ErrorMessage = $"Account has insufficent shares.  You only have {e.RequiredShares} shares to sell.";
            }
            catch (Exception)
            {
                _sellViewModel.ErrorMessage = "Transaction Failed.";
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _sellViewModel.CanSellStock && base.CanExecute(parameter);
        }
    }
}
