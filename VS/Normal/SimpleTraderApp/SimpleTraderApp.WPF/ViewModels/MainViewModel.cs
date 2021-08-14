using SimpleTraderApp.WPF.State.Authenticators;
using SimpleTraderApp.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }
        public IAuthenticator Authenticator { get;  }

        public MainViewModel(INavigator navigator, IAuthenticator authenticator)
        {
            this.Navigator = navigator;
            Authenticator = authenticator;
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Login );
        }
    }
}
