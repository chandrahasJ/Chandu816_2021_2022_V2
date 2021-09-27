using Moq;
using NUnit.Framework;
using SimpleTraderApp.Domain.Exceptions;
using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.Domain.Services.TransactionServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.Domain.Test.Services.TransactionServices
{
    [TestFixture]
    public class SellStockServiceTest
    {
        private SellStockService _sellStockService;
        private Mock<IStockPriceService> _mockStockPriceService;
        private Mock<IDataService<Account>> _mockIDataService;

        [SetUp]
        public void Setup()
        {
            _mockStockPriceService = new Mock<IStockPriceService>();
            _mockIDataService = new Mock<IDataService<Account>>();

            _sellStockService = new SellStockService(_mockStockPriceService.Object, _mockIDataService.Object);
        }

        [Test]
        public void SellStock_WithInSuffientShares_ThrowInSuffientSharesException()
        {
            string expectedSymbol = "GE";
            int exceptedAccountShares = 0;
            int exceptedRequiredShares = 10;
            Account seller = CreateNewAccount(expectedSymbol, exceptedAccountShares);

            InsufficentSharesExpection insufficentSharesExpection = Assert
                    .ThrowsAsync<InsufficentSharesExpection>(() => _sellStockService.SellStock(seller, expectedSymbol, exceptedRequiredShares));

            string actualSymbols = insufficentSharesExpection.Symbol;
            int actualAccountShares = insufficentSharesExpection.AcountShares;
            int actualRequiredShare = insufficentSharesExpection.RequiredShares;

            Assert.AreEqual(expectedSymbol, actualSymbols);
            Assert.AreEqual(exceptedAccountShares, actualAccountShares);
            Assert.AreEqual(exceptedRequiredShares, actualRequiredShare);


        }

        [Test]
        public void SellStock_WithInvalidStock_ThrowInvalidSymbolExpection()
        {
            string expectedSymbol = "bad_symbol";
            int exceptedAccountShares = 10;
            
            Account seller = CreateNewAccount(expectedSymbol, exceptedAccountShares);
            _mockStockPriceService.Setup(s => s.GetPrice(expectedSymbol)).ThrowsAsync(new InvalidSymbolException(expectedSymbol));

            InvalidSymbolException invalidSymbolException = Assert.
                ThrowsAsync<InvalidSymbolException>(() => _sellStockService.SellStock(seller, expectedSymbol, exceptedAccountShares));
            string actualException = invalidSymbolException.Symbol;
 
            Assert.AreEqual(expectedSymbol, actualException);
        }

        [Test]
        public void SellStock_WithGetPriceFailure_ThrowExpection()
        { 
            Account seller = CreateNewAccount(It.IsAny<string>(),10);
            _mockStockPriceService.Setup(s => s.GetPrice(It.IsAny<string>())).ThrowsAsync(new Exception());
            Assert.ThrowsAsync<Exception>(() => _sellStockService.SellStock(seller, It.IsAny<string>(), 5));
             
        }

        [Test]
        public void SellStock_WithAccountFailure_ThrowExpection()
        {
            Account seller = CreateNewAccount(It.IsAny<string>(), 10);

            _mockIDataService.Setup(s => s.Update(It.IsAny<int>(), It.IsAny<Account>())).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(() => _sellStockService.SellStock(seller, It.IsAny<string>(), 5));
        }

        [Test]
        public async Task SellStock_WithSuccessfull_ReturnAccountWithNewTransaction()
        {
            int expextedTransactionCount = 2;

            Account seller = CreateNewAccount(It.IsAny<string>(), 10);

            seller = await _sellStockService.SellStock(seller, It.IsAny<string>(), 5);
            int actualTransactionCount = seller.AssetTrasactions.Count;

            Assert.AreEqual(expextedTransactionCount,actualTransactionCount);

        }

        private static Account CreateNewAccount(string symbol, int shares)
        {
            return new Account()
            {
                AssetTrasactions = new List<AssetTransaction>()
                {
                   new AssetTransaction()
                   {
                        Asset = new Asset()
                        {
                            Symbol = symbol,
                            PricePerShare = 0
                        },
                        IsPurchased = true,
                        Shares =shares
                   }
                }
            };
        }
    }
}
