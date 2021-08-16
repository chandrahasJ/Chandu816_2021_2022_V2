using SimpleTraderApp.WPF.State.Authenticators;
using SimpleTraderApp.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels.Factories
{
    public class LoginViewModelFactory : ISimpleTraderViewModelFactory<LoginViewModel>
    {
        private readonly IAuthenticator _authenticator;
        private readonly IReNavigator _reNavigator;

        public LoginViewModelFactory(IAuthenticator authenticator, IReNavigator reNavigator)
        {
            this._authenticator = authenticator;
            this._reNavigator = reNavigator;
        }

        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(_authenticator,_reNavigator);
        }
    }
}
