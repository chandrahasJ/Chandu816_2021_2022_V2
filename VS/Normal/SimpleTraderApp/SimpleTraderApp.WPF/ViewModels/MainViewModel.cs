using SimpleTraderApp.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }
        public MainViewModel(INavigator navigator)
        {
            this.Navigator = navigator;

            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Login );
        }
    }
}
