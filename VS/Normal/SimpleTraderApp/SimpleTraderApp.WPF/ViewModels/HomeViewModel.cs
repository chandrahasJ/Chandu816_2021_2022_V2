using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly MajorIndexViewModel majorIndexViewModel;

        public HomeViewModel(MajorIndexViewModel majorIndexViewModel)
        {
            this.majorIndexViewModel = majorIndexViewModel;
        }


    }
}
