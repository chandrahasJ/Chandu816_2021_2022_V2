using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services.AuthServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleTraderApp.Domain.Exceptions;

namespace SimpleTraderApp.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get;  }
        bool IsLoggedIn { get;  }
        event Action StateChanged;
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
        Task Login(string username, string password);
        void Logout();
    }
}
