using SimpleTraderApp.FMPrepAPI.Services;
using SimpleTraderApp.WPF.State.Navigators;
using SimpleTraderApp.WPF.ViewModels;
using SimpleTraderApp.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        private readonly INavigator _navigator;
        private readonly ISimpleTradeViewModelFactory _viewModelAbstractFactory;

        public event EventHandler CanExecuteChanged;

        public UpdateCurrentViewModelCommand(INavigator navigator, ISimpleTradeViewModelFactory viewModelAbstractFactory)
        {
            this._navigator = navigator;
            this._viewModelAbstractFactory = viewModelAbstractFactory;
        }

        public bool CanExecute(object parameter)
        {
            return  true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                _navigator.CurrentViewModel = _viewModelAbstractFactory.CreateViewModel(viewType);
            }
        }
    }
}