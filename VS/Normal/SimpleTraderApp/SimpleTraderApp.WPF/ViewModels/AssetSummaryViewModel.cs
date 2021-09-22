using SimpleTraderApp.WPF.State.Assets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class AssetSummaryViewModel : ViewModelBase
    {
        private readonly AssetStore _assetStore;

        public double AccountBalance => _assetStore.AccountBalance;
        public AssetListingViewModel AssetListingViewModel { get; }

        public AssetSummaryViewModel(AssetStore assetStore)
        {
            this._assetStore = assetStore;
            AssetListingViewModel = new AssetListingViewModel(assetStore, assetStore => assetStore.Take(3));
            _assetStore.StateChanged += _assetStore_StateChanged;
        }

        private void _assetStore_StateChanged()
        {
            OnPropertyChanged(nameof(AccountBalance));
        }
    }
}
