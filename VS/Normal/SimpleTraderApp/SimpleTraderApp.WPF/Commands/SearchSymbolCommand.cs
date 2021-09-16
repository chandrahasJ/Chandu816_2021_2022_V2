using SimpleTraderApp.Domain.Exceptions;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.Commands
{
    public class SearchSymbolCommand : AsyncCommandBase
    {
        private  readonly BuyViewModel _buyViewModel;
        private readonly IStockPriceService _stockPriceService;

        public SearchSymbolCommand(BuyViewModel buyViewModel, IStockPriceService stockPriceService)
        {
            this._buyViewModel = buyViewModel;
            this._stockPriceService = stockPriceService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _buyViewModel.ErrorMessage = String.Empty;
            _buyViewModel.StatusMessage = String.Empty;
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
