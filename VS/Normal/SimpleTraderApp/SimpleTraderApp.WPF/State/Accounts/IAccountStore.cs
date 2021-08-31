using SimpleTraderApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.State.Accounts
{
    public interface IAccountStore
    {
        public Account CurrentAccount { get; set; }
    }
}
