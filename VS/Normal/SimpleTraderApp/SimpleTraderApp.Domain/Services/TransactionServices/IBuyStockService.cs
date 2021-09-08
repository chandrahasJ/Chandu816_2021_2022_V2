using SimpleTraderApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleTraderApp.Domain.Exceptions;

namespace SimpleTraderApp.Domain.Services.TransactionServices
{
    public interface IBuyStockService
    {
        /// <summary>
        /// Buy Stock 
        /// </summary>
        /// <param name="buyer">Buyers Account </param>
        /// <param name="stock">Stock Name</param>
        /// <param name="shares">Shares Count</param>
        /// <exception cref="InsufficentFundExpection">Account doesn't have sufficent funds.</exception>
        /// <exception cref="InvalidSymbolException">Symbol doesn't exists.</exception>
        /// /// <exception cref="Exception">Transaction Falied.</exception>
        /// <returns></returns>
        Task<Account> BuyStock(Account buyer, string stock, int shares);

    }
}
