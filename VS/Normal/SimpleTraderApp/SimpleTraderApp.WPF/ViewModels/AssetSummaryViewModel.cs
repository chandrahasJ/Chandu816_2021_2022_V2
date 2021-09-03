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

        private readonly ObservableCollection<AssetViewModel> _assets;

        public double AccountBalance => _assetStore.AccountBalance;
        public IEnumerable<AssetViewModel> TopAssets => _assets;

        public AssetSummaryViewModel(AssetStore assetStore)
        {
            this._assetStore = assetStore;
            _assets = new ObservableCollection<AssetViewModel>();
            _assetStore.StateChanged += _assetStore_StateChanged;
            ResetBalance();
        }

        private void _assetStore_StateChanged()
        {
            OnPropertyChanged(nameof(AccountBalance));
            ResetBalance();
        }

        private void ResetBalance()
        {
            IEnumerable<AssetViewModel> assetViewModels = _assetStore.AssetTransactions
                                                .GroupBy(a => a.Asset.Symbol)
                                                .Select(g => new AssetViewModel(g.Key, g.Sum(z => z.IsPurchased ? z.Shares : -z.Shares)))                                                
                                                .Where(x => x.Shares > 0)
                                                .OrderByDescending(z => z.Shares)
                                                .Take(3);

            _assets.Clear();

            foreach (AssetViewModel assetViewModel in assetViewModels)
            {
                _assets.Add(assetViewModel);
            }
        }
    }
}
