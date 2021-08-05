using Microsoft.AspNet.Identity;
using SimpleTraderApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.Domain.Services.AuthServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountDataService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountDataService, IPasswordHasher passwordHasher)
        {
            this._accountDataService = accountDataService;
            this._passwordHasher = passwordHasher;
        }

        public async Task<Account> Login(string username, string password)
        {
            Account storedAccount = await _accountDataService.GetByUserName(username);
            PasswordVerificationResult passwordVerificationResult = _passwordHasher.VerifyHashedPassword(storedAccount.AccountHolder.PasswordHash, password);
            if (passwordVerificationResult != PasswordVerificationResult.Success)
            {
                throw new Exception("Fa");
            }

            return storedAccount;
        }

        public async Task<bool> Register(string emailId, string username, string password, string confirmPassword)
        {
            bool success = true;
            if (password == confirmPassword)
            {
                
                string hashedPassword = _passwordHasher.HashPassword(password);

                User user = new User()
                {
                    Email = emailId,
                    UserName = username,                    
                    DateJoined = DateTime.Now,
                    PasswordHash = hashedPassword
                };

                Account account = new Account()
                {
                    AccountHolder = user
                };

                await _accountDataService.Create(account);
            }
            return success;
        }
    }
}
