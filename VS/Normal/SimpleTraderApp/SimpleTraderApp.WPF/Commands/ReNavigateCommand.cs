using SimpleTraderApp.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.Commands
{
    public class ReNavigateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly IReNavigator reNavigator;

        public ReNavigateCommand(IReNavigator reNavigator)
        {
            this.reNavigator = reNavigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.reNavigator.ReNavigate();
        }
    }
}
