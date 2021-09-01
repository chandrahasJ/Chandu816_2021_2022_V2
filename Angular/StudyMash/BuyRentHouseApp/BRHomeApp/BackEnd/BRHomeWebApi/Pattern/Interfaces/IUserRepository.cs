using System.Threading.Tasks;
using BRHomeWebApi.Models;

namespace BRHomeWebApi.Pattern.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string userName,string passWord );
    }
}