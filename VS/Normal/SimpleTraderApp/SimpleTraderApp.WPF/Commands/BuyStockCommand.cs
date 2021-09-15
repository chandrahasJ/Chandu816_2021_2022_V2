﻿using SimpleTraderApp.Domain.Exceptions;
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
    }
}
