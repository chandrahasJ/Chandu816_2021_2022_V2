using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.Domain.Services
{
    public interface  IStockPriceService
    {
        Task<double> GetPrice(string symbol);

        void SetApiKey(string _APIKey);
    }
}
