using SimpleTraderApp.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels.Factories
{
    public interface ISimpleTradeViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
