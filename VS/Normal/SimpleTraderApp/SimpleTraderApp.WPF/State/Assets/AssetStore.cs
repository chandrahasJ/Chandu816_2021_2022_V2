using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.WPF.State.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.State.Assets
{
    public class AssetStore 
    {
        private readonly IAccountStore _accountStore;

        public double AccountBalance => _accountStore.CurrentAccount?.Balance ?? 0;

        public IEnumerable<AssetTransaction> AssetTransactions => _accountStore.CurrentAccount.AssetTrasactions ?? new List<AssetTransaction>();

        public event Action StateChanged;

        public AssetStore(IAccountStore accountStore)
        {
            this._accountStore = accountStore;

            _accountStore.StateChanged += _accountStore_StateChanged;
        }

        private void _accountStore_StateChanged()
        {
            StateChanged?.Invoke();
        }
    }
}
