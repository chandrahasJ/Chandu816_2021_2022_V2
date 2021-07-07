using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.Domain.Models
{
    public class Account : DomainObject
    {
        public User AccountHolder { get; set; }
        public double Balance { get; set; }
        public IEnumerable<AssetTrasaction> AssetTrasactions { get; set; }
    }
}
