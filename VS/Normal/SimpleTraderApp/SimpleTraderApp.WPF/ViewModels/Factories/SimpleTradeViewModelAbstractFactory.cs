using SimpleTraderApp.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels.Factories
{
    public class SimpleTradeViewModelAbstractFactory : ISimpleTradeViewModelAbstractFactory
    {
        private readonly ISimpleTraderViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;

        public SimpleTradeViewModelAbstractFactory(
                ISimpleTraderViewModelFactory<HomeViewModel> homeViewModelFactory,
                ISimpleTraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory
            )
        {
            _homeViewModelFactory = homeViewModelFactory;
            this._portfolioViewModelFactory = portfolioViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Portfolio:
                    return _portfolioViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("View Type does not have View Model", "View Type");
            }
        }
    }
}
