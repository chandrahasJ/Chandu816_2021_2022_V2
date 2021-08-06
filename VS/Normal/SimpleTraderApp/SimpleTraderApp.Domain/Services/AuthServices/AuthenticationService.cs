using Microsoft.AspNet.Identity;
using SimpleTraderApp.Domain.Exceptions;
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
                throw new InvalidPasswordException(username, password);
            }

            return storedAccount;
        }

        public async Task<RegisterResult> Register(string emailId, string username, string password, string confirmPassword)
        {
            RegisterResult registerResult = RegisterResult.Success;

            if (password != confirmPassword)
            {
                registerResult = RegisterResult.PasswordDoNotMatch;
            }                

            Account emailAccount = await _accountDataService.GetByEmailId(emailId);
            if (emailAccount != null)
            {
                registerResult = RegisterResult.EmailAlreadyExists;
            }

            Account userNameAccount = await _accountDataService.GetByUserName(username);
            if (userNameAccount != null)
            {
                registerResult = RegisterResult.UserNameAlreadyExists;
            }

            if (registerResult == RegisterResult.Success)
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
                       
            return registerResult;
        }
    }
}
