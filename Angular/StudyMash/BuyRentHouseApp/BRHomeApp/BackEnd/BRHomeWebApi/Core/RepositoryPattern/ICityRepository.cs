using System.Collections.Generic;
using System.Threading.Tasks;
using BRHomeWebApi.Models;

namespace BRHomeWebApi.Core.RepositoryPattern
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        void AddCity(City city);

        void DeleteCity(int id);
        Task<bool> SaveAsync();
    }
}