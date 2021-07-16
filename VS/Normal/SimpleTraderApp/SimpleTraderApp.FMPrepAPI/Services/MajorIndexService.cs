using Newtonsoft.Json;
using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.FMPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        private readonly string aPIKey;

        public MajorIndexService(string _APIKey)
        {
            aPIKey = _APIKey;
        }

        public async Task<MajorIndex> GetMajorIndex(MajorIndexType majorIndexType)
        {
            string urlMajorIndex = $"https://financialmodelingprep.com/api/v3/majors-indexes/{GetUriSuffix(majorIndexType)}?{GetAPIQuery()}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync(urlMajorIndex);
                string jsonReponse = await responseMessage.Content.ReadAsStringAsync();

                MajorIndex majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonReponse);
                majorIndex.Type = majorIndexType;
                return majorIndex; 
            }
        }

        private string GetUriSuffix(MajorIndexType majorIndexType)
        {
            switch (majorIndexType)
            {
                case MajorIndexType.DowJones:
                    return ".DJI";
                    break;
                case MajorIndexType.Nasdaq:
                    return ".IXIC";
                case MajorIndexType.SP500:
                    return ".INX";
                default:
                    return ";";
            }
        }

        public string GetAPIQuery()
        {
            return $"apikey={aPIKey}";
        }



    }
}