using System.Linq;
using System.Threading.Tasks;
using BRHomeWebApi.DataC;
using BRHomeWebApi.Models;
using BRHomeWebApi.Pattern.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BRHomeWebApi.Pattern.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BRHomeDbContext _bRHomeDbContext;

        public UserRepository(BRHomeDbContext bRHomeDbContext)
        {
            this._bRHomeDbContext = bRHomeDbContext;
        }

        public async Task<User> Authenticate(string userName, string passWord)
        {
            return await _bRHomeDbContext.Users.FirstOrDefaultAsync(
                x => x.UserName == userName 
                &&
                x.Password == passWord
            );
        }
    }
}