using System.Threading.Tasks;

namespace BRHomeWebApi.Pattern.Interfaces
{
    public interface IUnitOfWork
    {
        public ICityRepository cityRepository { get; }
        public IUserRepository userRepository { get;  }
        Task<bool> SaveAsync();
    }
}