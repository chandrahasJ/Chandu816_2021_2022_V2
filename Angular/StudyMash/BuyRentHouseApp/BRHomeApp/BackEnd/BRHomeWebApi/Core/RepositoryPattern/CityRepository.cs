using System.Collections.Generic;
using System.Threading.Tasks;
using BRHomeWebApi.DataC;
using BRHomeWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BRHomeWebApi.Core.RepositoryPattern
{
    public class CityRepository : ICityRepository
    {
        private readonly BRHomeDbContext _bRHomeDbContext;

        public CityRepository(BRHomeDbContext bRHomeDbContext)
        {
            this._bRHomeDbContext = bRHomeDbContext;
        }
        public void AddCity(City city)
        {
            _bRHomeDbContext.Cities.AddAsync(city);            
        }

        public void DeleteCity(int id)
        {
            var city = _bRHomeDbContext.Cities.Find(id);
            _bRHomeDbContext.Cities.Remove(city);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
          return await _bRHomeDbContext.Cities.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
             return await _bRHomeDbContext.SaveChangesAsync() > 0 ;
        }
    }
}