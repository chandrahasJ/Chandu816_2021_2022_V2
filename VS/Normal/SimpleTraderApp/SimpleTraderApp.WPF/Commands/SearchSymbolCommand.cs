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
        private  readonly ISearchSymbolViewModel _searchSymbolViewModel ;
        private readonly IStockPriceService _stockPriceService;

        public SearchSymbolCommand(ISearchSymbolViewModel ViewModel, IStockPriceService stockPriceService)
        {
            this._searchSymbolViewModel = ViewModel;
            this._stockPriceService = stockPriceService;

            this._searchSymbolViewModel.PropertyChanged += _searchSymbolViewModel_PropertyChanged;
        }

        private void _searchSymbolViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ISearchSymbolViewModel.CanSearchSymbol))
            {
                OnCanExecuteChanged();
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _searchSymbolViewModel.ErrorMessage = String.Empty;
            _searchSymbolViewModel.StatusMessage = String.Empty;
            try
            {
                double stockPrice = await _stockPriceService.GetPrice(_searchSymbolViewModel.Symbol);
                _searchSymbolViewModel.SearchResultSymbol = _searchSymbolViewModel.Symbol.ToUpper();
                _searchSymbolViewModel.StockPrice = stockPrice;
            }
            catch (InvalidSymbolException)
            {
                _searchSymbolViewModel.ErrorMessage = "Symbol does not exists.";
            }
            catch (Exception)
            {
                _searchSymbolViewModel.ErrorMessage = "Transaction Failed.";
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _searchSymbolViewModel.CanSearchSymbol && base.CanExecute(parameter);
        }
    }
}
