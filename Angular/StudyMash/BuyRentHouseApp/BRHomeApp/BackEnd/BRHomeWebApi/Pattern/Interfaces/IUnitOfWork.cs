using System.Threading.Tasks;

namespace BRHomeWebApi.Pattern.Interfaces
{
    public interface IUnitOfWork
    {
        public ICityRepository cityRepository { get; }
        public IUserRepository userRepository { get;  }
        public IPropertyRepository propertyRepository { get; }
        public IPropertyTypeRepository propertyTypeRepository { get; }
        public IFurnishTypeRepository furnishTypeRepository { get; }
        Task<bool> SaveAsync();
    }
}