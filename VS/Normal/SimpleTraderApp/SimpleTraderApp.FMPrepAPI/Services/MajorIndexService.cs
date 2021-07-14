using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.FMPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public Task<MajorIndex> GetMajorIndex(MajorIndexType majorIndexType)
        {
            throw new NotImplementedException();
        }
    }
}
