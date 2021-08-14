using SimpleTraderApp.WPF.State.Authenticators;
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
        private readonly LoginViewModel _loginViewModel;

        public LoginCommand( LoginViewModel loginViewModel, IAuthenticator authenticator)
        {
            this._authenticator = authenticator;
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
                await _authenticator.Login(_loginViewModel.UserName, parameter.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
