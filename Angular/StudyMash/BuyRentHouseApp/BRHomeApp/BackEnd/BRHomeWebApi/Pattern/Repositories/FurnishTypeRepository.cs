using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRHomeWebApi.DataC;
using BRHomeWebApi.Models;
using BRHomeWebApi.Pattern.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BRHomeWebApi.Pattern.Repositories
{
    public class FurnishTypeRepository : IFurnishTypeRepository
    {
        private readonly BRHomeDbContext bRHomeDbContext;
        public FurnishTypeRepository(BRHomeDbContext bRHomeDbContext)
        {
            this.bRHomeDbContext = bRHomeDbContext;

        }
        public async Task<IEnumerable<FurnishingType>> GetFurnishingTypeAsync()
        {
            return await bRHomeDbContext.FurnishingTypes.ToListAsync();
        }
    }
}