using SimpleTraderApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.State.Navigators
{
    public enum ViewType
    {
        Home,
        Portfolio,
        Buy,
        Login
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
