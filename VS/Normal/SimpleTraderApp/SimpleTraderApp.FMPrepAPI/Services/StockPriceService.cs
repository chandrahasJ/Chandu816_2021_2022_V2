using Newtonsoft.Json;
using SimpleTraderApp.Domain.Exceptions;
using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.FMPrepAPI.Results;
using System;
using System.Collections.Generic;
using System.Linq;
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
                string urlStockPrice = $"quote-short/{symbol.ToUpper()}?{GetAPIQuery()}";

                List<StockPriceResult> stockPriceResult = await client.GetTaskAsync<List<StockPriceResult>>(urlStockPrice);
                
                if (stockPriceResult.Count != 0)
                {
                    var getStockPrice = stockPriceResult.FirstOrDefault();
                    if (getStockPrice.Price == 0)
                    {
                        throw new InvalidSymbolException(symbol);
                    }
                    return getStockPrice.Price;
                }
                else
                {
                    throw new InvalidSymbolException(symbol);
                }
            }
        }

        public string GetAPIQuery()
        {
            return $"apikey={aPIKey}";
        }
    }
}
