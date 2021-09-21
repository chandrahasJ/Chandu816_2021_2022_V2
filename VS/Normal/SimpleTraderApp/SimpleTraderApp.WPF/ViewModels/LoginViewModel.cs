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
        private readonly IReNavigator _reLoginNavigator;
        private readonly IReNavigator _reRegisterNavigator;

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

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand  LoginCommand { get; }
        public ICommand ViewRegisterCommand { get; }
        
        public MessageViewModel ErrorMessageViewModel { get; }
        public string ErrorMessage { set => ErrorMessageViewModel.Message = value; }

        public LoginViewModel(IAuthenticator authenticator, IReNavigator reLoginNavigator, IReNavigator reRegisterNavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();
            this._authenticator = authenticator;
            this._reLoginNavigator = reLoginNavigator;
            this._reRegisterNavigator = reRegisterNavigator;
            LoginCommand = new LoginCommand(this, authenticator, _reLoginNavigator);

            ViewRegisterCommand = new ReNavigateCommand(reRegisterNavigator);
        }
    }
}
