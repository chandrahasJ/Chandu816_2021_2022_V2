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
            bRHomeDbContext.Properties.Add(property);
        }

        public void DeleteProperty(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Property>> GetProperties(int sellRent)
        {
            var properties = await bRHomeDbContext.Properties
                                            .Include(i => i.City)
                                            .Include(i => i.PropertyType)
                                            .Include(i => i.FurnishingType)
                                             .Include(i => i.Photos)
                                            .Where(w => w.SellRent == sellRent)
                                            .ToListAsync();
            return properties;
        }

        public async Task<Property> GetPropertyDetails(int id)
        {
            var property = await bRHomeDbContext.Properties
                                            .Include(i => i.City)
                                            .Include(i => i.PropertyType)
                                            .Include(i => i.FurnishingType)
                                            .Include(i => i.Photos)
                                            .Where(w => w.Id == id)
                                            .FirstOrDefaultAsync();
            return property;
        }

        public async Task<Property> GetPropertyDetailsById(int id)
        {
             var property = await bRHomeDbContext.Properties                                            
                                            .Include(i => i.Photos)
                                            .Where(w => w.Id == id)
                                            .FirstOrDefaultAsync();
            return property;
        }
    }
}