using Moq;
using NUnit.Framework;
using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.Domain.Services.TransactionServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.Domain.Test.Services.TransactionServices
{
    [TestFixture]
    public class BuyStockServiceTest
    {
        private BuyStockService _buyStockService;
        private Mock<IStockPriceService> _mockStockPriceService;
        private Mock<IDataService<Account>> _mockIDataService;

        public void Setup()
        {
            _mockStockPriceService = new Mock<IStockPriceService>();
            _mockIDataService = new Mock<IDataService<Account>>();

            _buyStockService = new BuyStockService(_mockStockPriceService.Object, _mockIDataService.Object);
        }
    }
}
