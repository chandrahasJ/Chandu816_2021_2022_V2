using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class AssetViewModel
    {
        public AssetViewModel( string symbol, int shares)
        {
            Shares = shares;
            Symbol = symbol;
        }

        public int Shares { get; set; }
        public string Symbol { get; set; }

        
    }
}
