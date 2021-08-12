using System.Threading.Tasks;

namespace BRHomeWebApi.Pattern.Interfaces
{
    public interface IUnitOfWork
    {
        public ICityRepository cityRepository { get; }
        Task<bool> SaveAsync();
    }
}