using SimpleTraderApp.WPF.Commands;
using SimpleTraderApp.WPF.Models;
using SimpleTraderApp.WPF.ViewModels;
using SimpleTraderApp.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.State.Navigators
{
    public class Navigator : ObservableObject,  INavigator 
    {
        private ViewModelBase _currentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public Navigator(ISimpleTradeViewModelAbstractFactory viewModelAbstractFactory)
        {
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this, viewModelAbstractFactory);
        }

        public ViewModelBase CurrentViewModel { get => _currentViewModel;
            set 
            { 
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            } 
        }

    }
}
