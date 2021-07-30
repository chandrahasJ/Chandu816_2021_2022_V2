using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels.Factories
{
    public class HomeViewModelFactory : ISimpleTraderViewModelFactory<HomeViewModel>
    {
        private readonly ISimpleTraderViewModelFactory<MajorIndexListingViewModel> _simpleTraderViewModelFactory;

        public HomeViewModelFactory(ISimpleTraderViewModelFactory<MajorIndexListingViewModel> simpleTraderViewModelFactory)
        {
            this._simpleTraderViewModelFactory = simpleTraderViewModelFactory;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_simpleTraderViewModelFactory.CreateViewModel());
        }
    }
}
