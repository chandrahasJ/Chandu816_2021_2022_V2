using SimpleTraderApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleTraderApp.Domain.Exceptions;

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

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <exception cref="UserNameNotFoundException">Thrown if User name not found.</exception>
        /// <exception cref="InvalidPasswordException">Thrown if Password is incorrect.</exception>
        /// <exception cref="Exception">Thrown if login fails.</exception>
        /// <returns></returns>
        Task<Account> Login(string username, string password);
    }
}
