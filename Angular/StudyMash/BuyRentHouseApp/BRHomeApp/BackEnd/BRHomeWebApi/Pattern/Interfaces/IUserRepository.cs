using System.Threading.Tasks;
using BRHomeWebApi.Models;

namespace BRHomeWebApi.Pattern.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string userName,string passWord );

        void Register(string userName,string passWord );

        Task<bool> IsUserExistAlready(string userName);
    }
}