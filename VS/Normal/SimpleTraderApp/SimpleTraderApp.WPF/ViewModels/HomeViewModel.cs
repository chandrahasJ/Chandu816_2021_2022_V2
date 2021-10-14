using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public AssetSummaryViewModel AssetSummaryViewModel { get;  }
        public MajorIndexListingViewModel MajorIndexListngViewModel { get;  }

        public HomeViewModel(AssetSummaryViewModel AssetSummaryViewModel, MajorIndexListingViewModel majorIndexListingViewModel)
        {
            this.AssetSummaryViewModel = AssetSummaryViewModel;
            this.MajorIndexListngViewModel = majorIndexListingViewModel;
        }

        public override void Dispose()
        {
            AssetSummaryViewModel?.Dispose();
            MajorIndexListngViewModel.Dispose();

            base.Dispose();
        }
    }
}
