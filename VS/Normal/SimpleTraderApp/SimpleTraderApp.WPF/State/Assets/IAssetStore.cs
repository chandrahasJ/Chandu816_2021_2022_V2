using SimpleTraderApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.State.Assets
{
    public interface IAssetStore
    {
        double AccountBalance { get;  }
        IEnumerable<AssetTransaction> AssetTransactions { get; }
        event Action StateChanged;
    }
}
