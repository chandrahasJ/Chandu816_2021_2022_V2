using SimpleTraderApp.WPF.State.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;

        public LoginCommand(IAuthenticator authenticator)
        {
            this._authenticator = authenticator;
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

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
