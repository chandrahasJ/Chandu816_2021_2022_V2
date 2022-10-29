using DataExtractor.Services.Base;
using Microsoft.VisualBasic;
using NSE.Model;
using DataExtractor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Constants = NSE.Model.Constants;

namespace DataExtractor.Services
{
    public class OptionChainService : RestServiceBase, IOptionChainService
    {
        public OptionChainService()
        {
            SetBaseURL(Constants.ApiServiceURL);
        }

        public async Task<Root> GetOptionChainData(string symbol)
        {
            var resourceURI = String.Format(Constants.OptionChainQuery,symbol);

            var result = await GetAsync<Root>(resourceURI);

            return result;
        }
    }
}
