using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            var user = await _bRHomeDbContext.Users.FirstOrDefaultAsync(
                x => x.UserName == userName 
            );

            if(user == null || user.PasswordKey == null){
                return null;
            }

            if(!MatchPasswordHash(passWord,user.Password, user.PasswordKey))
                return null;

            return user;
        }

        private bool MatchPasswordHash(string passwordText, byte[] password, byte[] passwordKey)
        {
            using(var hmac = new  HMACSHA512(passwordKey))
            { 
                var  passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordText));     

                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if(passwordHash[i] != password[i])
                        return false;
                }           
                return true;
            }
        }

        public async Task<bool> IsUserExistAlready(string userName)
        {
          return  await _bRHomeDbContext.Users.AnyAsync(x => x.UserName == userName);
        }

        public void Register(string userName, string passWord,string Email, long mobile)
        {
            byte[] passwordHash, passwordKey;
            using(var hmac = new  HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passWord));                
            }

            User user = new User(){
                UserName = userName,
                Password = passwordHash,
                PasswordKey = passwordKey,
                Email = Email,
                Mobile = mobile
            };

            _bRHomeDbContext.Users.Add(user);
        }
    }
}