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
    public class PropertyRepository : IPropertyRepository
    {
        private readonly BRHomeDbContext bRHomeDbContext;

        public PropertyRepository(BRHomeDbContext bRHomeDbContext)
        {
            this.bRHomeDbContext = bRHomeDbContext;
        }
        public void AddProperty(Property property)
        {
            throw new NotImplementedException();
        }

        public void DeleteProperty(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Property>> GetProperties(int sellRent)
        {
            var properties = await bRHomeDbContext.Properties.ToListAsync();
            return properties;
        }
    }
}