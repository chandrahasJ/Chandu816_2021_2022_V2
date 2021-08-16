using SimpleTraderApp.WPF.State.Authenticators;
using SimpleTraderApp.WPF.State.Navigators;
using SimpleTraderApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.Commands
{
    public class LoginCommand : ICommand
    {

        private readonly IAuthenticator _authenticator;
        private readonly IReNavigator _reNavigator;
        private readonly LoginViewModel _loginViewModel;

        public LoginCommand( LoginViewModel loginViewModel, IAuthenticator authenticator, IReNavigator reNavigator)
        {
            this._authenticator = authenticator;
            this._reNavigator = reNavigator;
            this._loginViewModel = loginViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        { 
            try
            {
               bool isSuccess =  await _authenticator.Login(_loginViewModel.UserName, parameter.ToString());
                if (isSuccess)
                {
                    _reNavigator.ReNavigate();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
