using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels.Factories
{
    public class LoginViewModelFactory : ISimpleTraderViewModelFactory<LoginViewModel>
    {
        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel();
        }
    }
}
