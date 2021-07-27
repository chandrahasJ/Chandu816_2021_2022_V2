using Newtonsoft.Json;
using SimpleTraderApp.Domain.Exceptions;
using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.FMPrepAPI.Results;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.FMPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        public string aPIKey { get; private set; }
        public StockPriceService()
        {

        }

        public StockPriceService(string _APIKey)
        {
            aPIKey = _APIKey;
        }

        public void SetApiKey(string _APIKey)
        {
            aPIKey = _APIKey;
        }

        public async Task<double> GetPrice(string symbol)
        {
            using (FMPrepHttpClient client = new FMPrepHttpClient())
            {
                string urlStockPrice = $"quote-short/{symbol}?{GetAPIQuery()}";

                StockPriceResult stockPriceResult = await client.GetTaskAsync<StockPriceResult>(urlStockPrice);
                if (stockPriceResult.Price == 0)
                {
                    throw new InvalidSymbolException(symbol);
                }
                return stockPriceResult.Price;
            }
        }

        public string GetAPIQuery()
        {
            return $"apikey={aPIKey}";
        }
    }
}
