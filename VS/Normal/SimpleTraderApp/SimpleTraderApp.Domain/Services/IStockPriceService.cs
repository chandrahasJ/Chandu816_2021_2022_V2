using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleTraderApp.Domain.Exceptions;

namespace SimpleTraderApp.Domain.Services
{
    public interface  IStockPriceService
    {
        /// <summary>
        /// Get Price from the API
        /// </summary>
        /// <param name="symbol">Symbol of the Asset</param>
        /// <exception cref="InvalidSymbolException">Symbol does not exists.</exception>
        /// <exception cref="Exception">Transaction failed.</exception>
        /// <returns></returns>
        Task<double> GetPrice(string symbol);

        void SetApiKey(string _APIKey);
    }
}
