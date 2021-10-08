using System.Threading.Tasks;
using BRHomeWebApi.DataC;
using BRHomeWebApi.Pattern.Interfaces;
using BRHomeWebApi.Pattern.Repositories;

namespace BRHomeWebApi.Pattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BRHomeDbContext _bRHomeDbContext;

        public UnitOfWork(BRHomeDbContext bRHomeDbContext)
        {
            this._bRHomeDbContext = bRHomeDbContext;
        }
        public ICityRepository cityRepository => 
                new CityRepository(_bRHomeDbContext);

        public IUserRepository userRepository =>
                new UserRepository(_bRHomeDbContext);

        public IPropertyRepository propertyRepository => 
                new PropertyRepository(_bRHomeDbContext);

        public IPropertyTypeRepository propertyTypeRepository =>
                new PropertyTypeRepository(_bRHomeDbContext);

        public IFurnishTypeRepository furnishTypeRepository => 
            new FurnishTypeRepository(_bRHomeDbContext);

        public async Task<bool> SaveAsync()
        {
            return await _bRHomeDbContext.SaveChangesAsync() > 0;
        }
    }
}