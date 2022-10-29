using NSE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor.Services
{
    public interface IOptionChainService
    {
        public Task<Root> GetOptionChainData(string symbol);
    }
}
