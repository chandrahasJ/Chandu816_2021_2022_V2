using SimpleTraderApp.WPF.Commands;
using SimpleTraderApp.WPF.State.Authenticators;
using SimpleTraderApp.WPF.State.Navigators;
using SimpleTraderApp.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IRootSimpleTradeViewModelFactory viewModelFactory;

        public INavigator Navigator { get; set; }
        public IAuthenticator Authenticator { get;  }
        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public MainViewModel(INavigator navigator, IRootSimpleTradeViewModelFactory viewModelFactory, IAuthenticator authenticator)
        {
            this.Navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            Authenticator = authenticator;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator , viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }

    }
}
