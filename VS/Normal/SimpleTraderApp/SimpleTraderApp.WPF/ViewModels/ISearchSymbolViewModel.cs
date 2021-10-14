using System.ComponentModel;

namespace SimpleTraderApp.WPF.ViewModels
{
    public interface ISearchSymbolViewModel : INotifyPropertyChanged
    {
        string ErrorMessage { set; }
        string SearchResultSymbol {  set; }
        double StockPrice {  set; }
        string Symbol { get; }
        string StatusMessage { set; }
        bool CanSearchSymbol { get;  }
    }
}