using SimpleTraderApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.Domain.Services.TransactionServices
{
    public interface ISellStockService
    {
        /// <summary>
        /// Sell Stock 
        /// </summary>
        /// <param name="buyer">Sellers Account </param>
        /// <param name="stock">Stock Name</param>
        /// <param name="shares">Shares Count</param>
        /// <exception cref="InsufficentSharesExpection">Account doesn't have sufficent shares.</exception>
        /// <exception cref="InvalidSymbolException">Symbol doesn't exists.</exception>
        /// /// <exception cref="Exception">Transaction Falied.</exception>
        /// <returns></returns>
        Task<Account> SellStock(Account seller, string symbol,int shares);
    }
}
