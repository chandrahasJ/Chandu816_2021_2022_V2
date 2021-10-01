using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRHomeWebApi.Models;

namespace BRHomeWebApi.Pattern.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetProperties(int sellRent);
        Task<Property> GetPropertyDetails(int id);
        void AddProperty(Property property);
        void DeleteProperty(int id);
    }
}