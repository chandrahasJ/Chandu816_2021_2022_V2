using SimpleTraderApp.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels.Factories
{
    public class RootSimpleTradeViewModelFactory : IRootSimpleTradeViewModelFactory
    {
        private readonly ISimpleTraderViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<LoginViewModel> _loginViewModelFactory;
        private readonly BuyViewModel _buyViewModel;

        public RootSimpleTradeViewModelFactory(
                ISimpleTraderViewModelFactory<HomeViewModel> homeViewModelFactory,
                ISimpleTraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory,
                ISimpleTraderViewModelFactory<LoginViewModel> loginViewModelFactory,
                BuyViewModel buyViewModel
            )
        {
            _homeViewModelFactory = homeViewModelFactory;
            this._portfolioViewModelFactory = portfolioViewModelFactory;
            this._loginViewModelFactory = loginViewModelFactory;
            this._buyViewModel = buyViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _loginViewModelFactory.CreateViewModel();
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Portfolio:
                    return _portfolioViewModelFactory.CreateViewModel();
                case ViewType.Buy:
                    return _buyViewModel;
                default:
                    throw new ArgumentException("View Type does not have View Model", "View Type");
            }
        }
    }
}
