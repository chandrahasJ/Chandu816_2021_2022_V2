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
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private readonly BRHomeDbContext brHomeDbContext;
        public PropertyTypeRepository(BRHomeDbContext brHomeDbContext)
        {
            this.brHomeDbContext = brHomeDbContext;

        }

        public async Task<IEnumerable<PropertyType>> GetPropertyTypeAsync()
        {
            return await brHomeDbContext.PropertyTypes.ToListAsync();
        }
    }
}