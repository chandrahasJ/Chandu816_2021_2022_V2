using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.Domain.Services.TransactionServices;
using SimpleTraderApp.WPF.Commands;
using SimpleTraderApp.WPF.State.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class BuyViewModel : ViewModelBase, ISearchSymbolViewModel
    {
        public BuyViewModel(IStockPriceService stockPriceService, IBuyStockService buyStockService, IAccountStore accountStore)
        {
            this.ErrorMessageViewModel = new MessageViewModel();
            this.StatusMessageViewModel = new MessageViewModel();
            this.SearchSymbolCommand = new SearchSymbolCommand(this, stockPriceService);
            this.BuyStockCommand = new BuyStockCommand(this, buyStockService, accountStore);

        }

        public override void Dispose()
        {
            ErrorMessageViewModel?.Dispose();
            StatusMessageViewModel?.Dispose();

            base.Dispose();
        }

        private string _symbol;
        public string Symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                _symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }

        private string _searchResultSymbol = string.Empty;
        public string SearchResultSymbol
        {
            get
            {
                return _searchResultSymbol;
            }
            set
            {
                _searchResultSymbol = value;
                OnPropertyChanged(nameof(SearchResultSymbol));
            }
        }


        private double _stockPrice;
        public double StockPrice
        {
            get
            {
                return _stockPrice;
            }
            set
            {
                _stockPrice = value;
                OnPropertyChanged(nameof(StockPrice));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private int _sharesToBuy;
        private readonly IAccountStore accountStore;

        public int SharesToBuy
        {
            get
            {
                return _sharesToBuy;
            }
            set
            {
                _sharesToBuy = value;
                OnPropertyChanged(nameof(SharesToBuy));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public double TotalPrice
        {
            get
            {
                return SharesToBuy * StockPrice;
            }
        }

        public ICommand SearchSymbolCommand { get; set; }

        public ICommand BuyStockCommand { get; set; }

        public MessageViewModel ErrorMessageViewModel { get; }
        public string ErrorMessage { set => ErrorMessageViewModel.Message = value; }
        public MessageViewModel StatusMessageViewModel { get; }
        public string StatusMessage { set => StatusMessageViewModel.Message = value; }
    }
}
