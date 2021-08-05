using SimpleTraderApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.Domain.Services
{
    public interface IAccountService : IDataService<Account>
    {
        Task<Account> GetByUserName(string username);

        Task<Account> GetByEmailId(string emailId);
    }
}
