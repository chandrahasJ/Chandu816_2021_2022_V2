using SimpleTraderApp.FMPrepAPI.Services;
using SimpleTraderApp.WPF.State.Navigators;
using SimpleTraderApp.WPF.ViewModels;
using SimpleTraderApp.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : AsyncCommandBase
    {
        private readonly INavigator _navigator;
        private readonly ISimpleTradeViewModelFactory _viewModelAbstractFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, ISimpleTradeViewModelFactory viewModelAbstractFactory)
        {
            this._navigator = navigator;
            this._viewModelAbstractFactory = viewModelAbstractFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                _navigator.CurrentViewModel = _viewModelAbstractFactory.CreateViewModel(viewType);
            }
        }
    }
}