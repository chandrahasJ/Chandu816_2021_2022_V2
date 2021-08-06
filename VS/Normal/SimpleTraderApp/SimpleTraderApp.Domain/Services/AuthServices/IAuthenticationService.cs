using SimpleTraderApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.Domain.Services.AuthServices
{
    public enum RegisterResult
    {
        Success,
        PasswordDoNotMatch,
        EmailAlreadyExists,
        UserNameAlreadyExists,
        Failed
    }

    public interface IAuthenticationService
    {
        Task<RegisterResult> Register(string emailId, string username, string password, string confirmPassword);

        Task<Account> Login(string username, string password);
    }
}
