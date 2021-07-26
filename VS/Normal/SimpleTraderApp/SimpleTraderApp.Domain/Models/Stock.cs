using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.Domain.Models
{
    public class Asset
    {
        public string Symbol { get; set; }
        public double PricePerShare { get; set; }
    }
}
