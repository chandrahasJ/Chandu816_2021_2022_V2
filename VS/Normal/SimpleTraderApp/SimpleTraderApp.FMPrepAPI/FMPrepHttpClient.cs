using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.FMPrepAPI
{
    public class FMPrepHttpClient : HttpClient
    {
        public FMPrepHttpClient()
        {
            this.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/");
        }

        public async Task<T> GetTaskAsync<T>(string uri)
        {
            HttpResponseMessage responseMessage = await GetAsync(uri);
            string jsonReponse = await responseMessage.Content.ReadAsStringAsync();

            return  JsonConvert.DeserializeObject<T>(jsonReponse);

        }
    }
}
