using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleTraderApp.Domain.Exceptions
{
    public class InsufficentSharesExpection : Exception
    {
        public int AcountShares { get; set; }
        public int RequiredShares { get; set; }
        public string Symbol { get; set; }

        public InsufficentSharesExpection(int acountShares, int requiredShares, string symbol)
        {
            AcountShares = acountShares;
            RequiredShares = requiredShares;
            Symbol = symbol;
        }

        public InsufficentSharesExpection(string message, int acountShares, int requiredShares, string symbol) : base(message)
        {
            AcountShares = acountShares;
            RequiredShares = requiredShares;
            Symbol = symbol;
        }

        public InsufficentSharesExpection(string message, Exception innerException, int acountShares, int requiredShares, string symbol) : base(message, innerException)
        {
            AcountShares = acountShares;
            RequiredShares = requiredShares;
            Symbol = symbol;
        }

    }
}
