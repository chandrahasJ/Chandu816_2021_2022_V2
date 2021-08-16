using SimpleTraderApp.WPF.ViewModels;
using SimpleTraderApp.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.State.Navigators
{
    public class ViewModelFactoryReNavigator<TViewModel> : IReNavigator where TViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly ISimpleTraderViewModelFactory<TViewModel> _viewModelFactory;

        public ViewModelFactoryReNavigator(INavigator navigator, ISimpleTraderViewModelFactory<TViewModel> viewModelFactory)
        {
            this._navigator = navigator; 
            this._viewModelFactory = viewModelFactory;
        }

        public void ReNavigate()
        {
            _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel();
        }
    }
}
