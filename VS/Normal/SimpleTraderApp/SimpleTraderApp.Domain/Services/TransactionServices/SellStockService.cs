using SimpleTraderApp.Domain.Exceptions;
using SimpleTraderApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.Domain.Services.TransactionServices
{
    public class SellStockService : ISellStockService
    {
        private readonly IStockPriceService stockPriceService;
        private readonly IDataService<Account> dataService;

        public SellStockService(IStockPriceService stockPriceService, IDataService<Account> dataService)
        {
            this.stockPriceService = stockPriceService;
            this.dataService = dataService;
        }

        public async Task<Account> SellStock(Account seller, string symbol, int shares)
        {
            int accountShares = GetAccountSharesForSymbol(seller, symbol);
            if(accountShares < shares)
            {
                throw new InsufficentSharesExpection(accountShares,shares,symbol);
            }

            double stockPrice = await stockPriceService.GetPrice(symbol);

            seller.AssetTrasactions.Add(new AssetTransaction() { 
                Account = seller,
                Asset = new Asset()
                {
                    PricePerShare = stockPrice,
                    Symbol = symbol
                },
                DateProcessed = DateTime.Now,
                IsPurchased = false,
                Shares = shares
            });

            seller.Balance += shares * stockPrice;

            await dataService.Update(seller.Id, seller);

            return seller;
        }

        private int GetAccountSharesForSymbol(Account seller, string symbol)
        {
            var accountTransactionsForSymbol = seller.AssetTrasactions.Where(x => x.Asset.Symbol == symbol);
            return accountTransactionsForSymbol.Sum(x => x.IsPurchased ? x.Shares : -x.Shares);
        }
    }
}
