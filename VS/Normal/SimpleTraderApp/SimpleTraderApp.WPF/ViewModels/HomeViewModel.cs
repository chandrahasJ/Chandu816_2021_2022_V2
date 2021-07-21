using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public MajorIndexListingViewModel MajorIndexListngViewModel { get; set; }

        public HomeViewModel(MajorIndexListingViewModel majorIndexListingViewModel)
        {
            this.MajorIndexListngViewModel = majorIndexListingViewModel;
        }


    }
}
