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
    public class BuyStockServiceTest
    {
        private BuyStockService _buyStockService;
        private Mock<IStockPriceService> _mockStockPriceService;
        private Mock<IDataService<Account>> _mockIDataService;

        [SetUp]
        public void Setup()
        {
            _mockStockPriceService = new Mock<IStockPriceService>();
            _mockIDataService = new Mock<IDataService<Account>>();

            _buyStockService = new BuyStockService(_mockStockPriceService.Object, _mockIDataService.Object);
        }

        [Test]
        public void BuyStock_WithInsuffientMoney_ThrowInSuffientFundsException()
        {
            string expectedSymbol = "GE";
            int expectedAccountShares = 20;
            double expectedBalance = 0;
            double requiredBalance = 1000;
            Account buyer = CreateNewAccount(expectedBalance, expectedSymbol, expectedAccountShares);

            _mockStockPriceService.Setup(s => s.GetPrice(It.IsAny<string>())).ReturnsAsync(requiredBalance);

            InsufficentFundExpection insufficentFundExpection = Assert
                                            .ThrowsAsync<InsufficentFundExpection>(() =>                                            
                                                _buyStockService.BuyStock(buyer, expectedSymbol, expectedAccountShares)
                                            );

            double expectedAccountBalance = insufficentFundExpection.AccountBalance;
            double excpetedRequriedBalance = insufficentFundExpection.RequiredBalance;

            Assert.AreEqual(expectedBalance, expectedAccountBalance);
            Assert.AreEqual(requiredBalance * expectedAccountShares, excpetedRequriedBalance);
        }

        [Test]
        public void BuyStock_WithInvalidSymbol_ThrowInvalidSymbolException()
        {
            string expectedSymbol = "bad_symbol";
            int exceptedAccountShares = 10;

            Account buyer = CreateNewAccount(It.IsAny<double>(), expectedSymbol, exceptedAccountShares);
            _mockStockPriceService.Setup(s => s.GetPrice(expectedSymbol)).ThrowsAsync(new InvalidSymbolException(expectedSymbol));

            InvalidSymbolException invalidSymbolException = Assert.
                ThrowsAsync<InvalidSymbolException>(() => _buyStockService.BuyStock(buyer, expectedSymbol, exceptedAccountShares));
            string actualException = invalidSymbolException.Symbol;

            Assert.AreEqual(expectedSymbol, actualException);
        }

        [Test]
        public void BuyStock_WithGetPrice_ThrowException()
        {
            _mockStockPriceService.Setup(s => s.GetPrice(It.IsAny<string>())).ThrowsAsync(new Exception()) ;

            Assert.ThrowsAsync<Exception>(() => _buyStockService.BuyStock(It.IsAny<Account>(), It.IsAny<string>(), It.IsAny<int>()));
        }

        [Test]
        public void BuyStock_WithAccountFailure_ThrowException()
        {
            string expectedSymbol = "GE";
            int expectedAccountShares = 20;
            double expectedBalance = 1000;
            double requiredBalance = 20000;
            Account buyer = CreateNewAccount(expectedBalance, expectedSymbol, expectedAccountShares);

            _mockStockPriceService.Setup(s => s.GetPrice(It.IsAny<string>())).ReturnsAsync(100);
            _mockIDataService.Setup(s => s.Update(It.IsAny<int>(), buyer)).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(() => _buyStockService.BuyStock(buyer, It.IsAny<string>(), 1));
        }

        [Test]
        public async Task BuyStock_WithAccountSuccessful_ReturnAccountWithDeductedMoney()
        {
            double expectedBalance = 0;
            double AccountBalance = 1000;

            _mockStockPriceService.Setup(s => s.GetPrice(It.IsAny<string>())).ReturnsAsync(10);
            Account buyer = CreateNewAccount(AccountBalance, It.IsAny<string>(), 10);
            buyer = await _buyStockService.BuyStock(buyer, It.IsAny<string>(), 100);
            double actualBalance = buyer.Balance;

            Assert.AreEqual(expectedBalance, actualBalance);

        }

        [Test]
        public async Task BuyStock_WithAccountSuccessful_ReturnAccountWithNewTransactions()
        {
            int expextedTransactionCount = 2;

            Account buyer = CreateNewAccount(It.IsAny<double>(), It.IsAny<string>(), 10);

            buyer = await _buyStockService.BuyStock(buyer, It.IsAny<string>(), 5);
            int actualTransactionCount = buyer.AssetTrasactions.Count;

            Assert.AreEqual(expextedTransactionCount, actualTransactionCount);
        }


        private static Account CreateNewAccount(double balance, string symbol, int shares)
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
                },
                Balance = balance               
            };
        }


    }
}
