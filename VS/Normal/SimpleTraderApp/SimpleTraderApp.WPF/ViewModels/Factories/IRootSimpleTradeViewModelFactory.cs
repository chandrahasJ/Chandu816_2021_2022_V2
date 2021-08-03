using SimpleTraderApp.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels.Factories
{
    public interface IRootSimpleTradeViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
