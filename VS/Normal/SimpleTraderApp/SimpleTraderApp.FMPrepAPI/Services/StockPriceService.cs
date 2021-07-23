using Newtonsoft.Json;
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
            using (HttpClient client = new HttpClient())
            {
                string urlStockPrice = $"https://financialmodelingprep.com/api/v3/quote-short/{symbol}?{GetAPIQuery()}";
                HttpResponseMessage responseMessage = await client.GetAsync(urlStockPrice);
                string jsonReponse = await responseMessage.Content.ReadAsStringAsync();

                StockPriceResult stockPriceResult = JsonConvert.DeserializeObject<StockPriceResult>(jsonReponse);
                return stockPriceResult.Price;
            }
        }

        public string GetAPIQuery()
        {
            return $"apikey={aPIKey}";
        }
    }
}
