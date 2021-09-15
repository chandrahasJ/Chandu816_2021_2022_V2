using SimpleTraderApp.Domain.Exceptions;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.Commands
{
    public class SearchSymbolCommand : ICommand
    {
        private   BuyViewModel _buyViewModel;
        private   IStockPriceService _stockPriceService;

        public event EventHandler CanExecuteChanged;
        public SearchSymbolCommand(BuyViewModel buyViewModel, IStockPriceService stockPriceService)
        {
            this._buyViewModel = buyViewModel;
            this._stockPriceService = stockPriceService;
        }

        public bool CanExecute(object parameter)
        {
            //return String.IsNullOrEmpty(_buyViewModel.StockPrice.ToString());
            return true;
        }

        public async void Execute(object parameter)
        {
            _buyViewModel.ErrorMessage = String.Empty;
            try
            {
                double stockPrice = await _stockPriceService.GetPrice(_buyViewModel.Symbol);
                _buyViewModel.SearchResultSymbol = _buyViewModel.Symbol.ToUpper();
                _buyViewModel.StockPrice = stockPrice;
            }
            catch (InvalidSymbolException)
            {
                _buyViewModel.ErrorMessage = "Symbol does not exists.";
            }
            catch (Exception)
            {
                _buyViewModel.ErrorMessage = "Transaction Failed.";
            }
        }
    }
}
