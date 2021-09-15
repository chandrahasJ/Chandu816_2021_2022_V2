using SimpleTraderApp.Domain.Exceptions;
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
                await _authenticator.Login(_loginViewModel.UserName, parameter.ToString());
                _reNavigator.ReNavigate();
            }
            catch(UserNameNotFoundException)
            {
                _loginViewModel.ErrorMessage = "Username doesn't exists.";
            }
            catch (InvalidPasswordException)
            {
                _loginViewModel.ErrorMessage = "Incorrect Password.";
            }
            catch (Exception)
            {
                _loginViewModel.ErrorMessage = "Login Failed.";
            }
        }
    }
}
