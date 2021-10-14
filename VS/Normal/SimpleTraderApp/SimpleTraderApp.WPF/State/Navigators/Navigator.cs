using SimpleTraderApp.WPF.Commands;
 
using SimpleTraderApp.WPF.ViewModels;
using SimpleTraderApp.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.State.Navigators
{
    public class Navigator :   INavigator 
    {
        private ViewModelBase _currentViewModel;
        public event Action StateChanged;

        public ViewModelBase CurrentViewModel { get => _currentViewModel;
            set 
            {
                _currentViewModel?.Dispose();

                _currentViewModel = value;
                StateChanged?.Invoke();
            } 
        }

    }
}
