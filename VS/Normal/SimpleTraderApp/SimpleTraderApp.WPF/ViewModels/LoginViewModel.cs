using SimpleTraderApp.WPF.Commands;
using SimpleTraderApp.WPF.State.Authenticators;
using SimpleTraderApp.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {     
        private string _userName;
        private readonly IAuthenticator _authenticator;
        private readonly IReNavigator _reNavigator;

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public ICommand  LoginCommand { get; }

        public LoginViewModel(IAuthenticator authenticator, IReNavigator reNavigator)
        {
            this._authenticator = authenticator;
            this._reNavigator = reNavigator;
            LoginCommand = new LoginCommand(this, authenticator, _reNavigator);
        }
    }
}
