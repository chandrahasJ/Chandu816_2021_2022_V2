using SimpleTraderApp.WPF.State.Assets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class AssetListingViewModel : ViewModelBase
    {
        private readonly AssetStore _assetStore;
        private readonly Func<IEnumerable<AssetViewModel>, IEnumerable<AssetViewModel>> filterAssests;
        private readonly ObservableCollection<AssetViewModel> _assets;

        public IEnumerable<AssetViewModel> TopAssets => _assets;

        public AssetListingViewModel(AssetStore assetStore) : this(assetStore, assets => assets)
        {

        }

        public AssetListingViewModel(AssetStore assetStore, Func<IEnumerable<AssetViewModel>,IEnumerable<AssetViewModel>> filterAssests)
        {
            this._assetStore = assetStore;
            this.filterAssests = filterAssests;
            _assets = new ObservableCollection<AssetViewModel>();
            _assetStore.StateChanged += _assetStore_StateChanged;
            ResetBalance();
        }

        private void _assetStore_StateChanged()
        { 
            ResetBalance();
        }

        private void ResetBalance()
        {
            IEnumerable<AssetViewModel> assetViewModels = _assetStore.AssetTransactions
                                                .GroupBy(a => a.Asset.Symbol)
                                                .Select(g => new AssetViewModel(g.Key, g.Sum(z => z.IsPurchased ? z.Shares : -z.Shares)))
                                                .Where(x => x.Shares > 0)
                                                .OrderByDescending(z => z.Shares);

            assetViewModels = filterAssests(assetViewModels);

            _assets.Clear();

            foreach (AssetViewModel assetViewModel in assetViewModels)
            {
                _assets.Add(assetViewModel);
            }
        }

    }
}
