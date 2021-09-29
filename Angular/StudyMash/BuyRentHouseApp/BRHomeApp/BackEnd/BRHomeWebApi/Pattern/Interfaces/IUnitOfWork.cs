using System.Threading.Tasks;

namespace BRHomeWebApi.Pattern.Interfaces
{
    public interface IUnitOfWork
    {
        public ICityRepository cityRepository { get; }
        public IUserRepository userRepository { get;  }
        public IPropertyRepository propertyRepository { get; }
        Task<bool> SaveAsync();
    }
}