using SimpleTraderApp.WPF.State.Assets;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class PortfolioViewModel : ViewModelBase
    {
        public AssetListingViewModel AssetListingViewModel { get;  }
        public PortfolioViewModel(AssetStore assetStore)
        {
            AssetListingViewModel = new AssetListingViewModel(assetStore);
        }
    }
}
