using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.Domain.Models
{
    public class AssetTrasaction : DomainObject
    {
        public Account Account { get; set; }
        public bool IsPurchased { get; set; }
        public Stock Stock { get; set; }
        public int Shares { get; set; }

        public DateTime DateProcessed { get; set; }
    }
}
