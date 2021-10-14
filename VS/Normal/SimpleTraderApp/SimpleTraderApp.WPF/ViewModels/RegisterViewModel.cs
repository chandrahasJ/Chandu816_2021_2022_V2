using SimpleTraderApp.WPF.Commands;
using SimpleTraderApp.WPF.State.Authenticators;
using SimpleTraderApp.WPF.State.Navigators;

using System.Windows.Input;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class RegisterViewModel: ViewModelBase
    {
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _username;
        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(UserName));
                OnPropertyChanged(nameof(CanRegister));
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
                OnPropertyChanged(nameof(CanRegister));
            }
        }
        
        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        public bool CanRegister => !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(UserName) &&
                                   !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmPassword);

        public ICommand RegisterCommand { get; }

        public ICommand ViewLoginCommand { get; }

        public MessageViewModel ErrorMessageViewModel { get; }
        public string ErrorMessage { set => ErrorMessageViewModel.Message = value; }

        public RegisterViewModel(IAuthenticator authenticator,  IReNavigator registerReNavigator, IReNavigator loginReNavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();

            ViewLoginCommand = new ReNavigateCommand(loginReNavigator);

            RegisterCommand = new RegisterCommand(this, authenticator, registerReNavigator);
        }

        public override void Dispose()
        {
            ErrorMessageViewModel?.Dispose();
            base.Dispose(); 
        }
    }
}
