using SimpleTraderApp.Domain.Services.AuthServices;
using SimpleTraderApp.WPF.State.Authenticators;
using SimpleTraderApp.WPF.State.Navigators;
using SimpleTraderApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.WPF.Commands
{
    public class RegisterCommand : AsyncCommandBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly RegisterViewModel _registerViewModel;
        private readonly IReNavigator _registerReNavigator;

        public RegisterCommand(RegisterViewModel registerViewModel, IAuthenticator authenticator, IReNavigator registerReNavigator)
        {
            this._authenticator = authenticator;
            this._registerViewModel = registerViewModel;
            this._registerReNavigator = registerReNavigator;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            _registerViewModel.ErrorMessage = string.Empty;
            try
            {
                RegisterResult registerResult = await _authenticator.Register(
                    _registerViewModel.Email,
                    _registerViewModel.UserName,
                    _registerViewModel.Password,
                    _registerViewModel.ConfirmPassword
                );

                switch (registerResult)
                {
                    case RegisterResult.Success:
                        _registerReNavigator.ReNavigate();
                        break;
                    case RegisterResult.PasswordDoNotMatch:
                        _registerViewModel.ErrorMessage = "Password doesn't match confirm Password";
                        break;
                    case RegisterResult.EmailAlreadyExists:
                        _registerViewModel.ErrorMessage = "Email Id already exists";
                        break;
                    case RegisterResult.UserNameAlreadyExists:
                        _registerViewModel.ErrorMessage = "UserName already exists";
                        break;
                    case RegisterResult.Failed:
                        _registerViewModel.ErrorMessage = "Registeration Failed.";
                        break;
                    default:
                        _registerViewModel.ErrorMessage = "Registeration Failed.";
                        break;
                }
            }
            catch (Exception)
            {
                _registerViewModel.ErrorMessage = "Registeration Failed.";
            }
        }
    }
}
