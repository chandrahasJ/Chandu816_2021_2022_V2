using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services.AuthServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get;  }
        bool IsLoggedIn { get;  }
        event Action StateChanged;
        Task<RegisterResult> Register(string emailId, string username, string password, string confirmPassword);
        Task<bool> Login(string username, string password);
        void Logout();
    }
}
