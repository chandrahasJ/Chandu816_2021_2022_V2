using SimpleTraderApp.Domain.Exceptions;
using SimpleTraderApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.Domain.Services.TransactionServices
{
    public class BuyStockService : IBuyStockService
    {
        private readonly IStockPriceService _StockPriceService;
        private readonly IDataService<Account> _AccountService;

        public BuyStockService(IStockPriceService stockPriceService, IDataService<Account> accountService)
        {
            this._StockPriceService = stockPriceService; 
            this._AccountService = accountService;
        }

        public async Task<Account> BuyStock(Account buyer, string symbol, int shares)
        {
            double stockPrice = await _StockPriceService.GetPrice(symbol);
            double transactionPrice = (stockPrice * shares);

            if (transactionPrice > buyer.Balance )
            {
                throw new InsufficentFundExpection(buyer.Balance, transactionPrice);
            }

            AssetTransaction transaction = new AssetTransaction()
            {
                Account = buyer,
                Asset = new Asset()
                {
                    PricePerShare = stockPrice,
                    Symbol = symbol
                },
                DateProcessed = DateTime.Now,
                Shares = shares,
                IsPurchased = true
            };

            buyer.AssetTrasactions.Add(transaction);
            buyer.Balance -= transactionPrice;

            await _AccountService.Update(buyer.Id, buyer);

            return buyer;
        }
    }
}
