using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using SimpleTraderApp.Domain.Exceptions;
using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.Domain.Services.AuthServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.Domain.Test.Services.AuthServices
{
   

    [TestFixture]
    public class AuthenticationServiceTests
    {
        private Mock<IAccountService> _mockAccountServices;
        private Mock<IPasswordHasher> _mockPasswordHasher;
        private AuthenticationService _mockAuthenticationService;

        [SetUp]
        public void Start()
        {
            _mockAccountServices = new Mock<IAccountService>();
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _mockAuthenticationService = new AuthenticationService(_mockAccountServices.Object, _mockPasswordHasher.Object);
        }

        [Test]
        public async Task Login_WithCorrectPasswordForExistingUserName_ReturnsAccountForCorrectUserName()
        {
            //Arrange
            string expectedUserName = "CP";
            string password = "test";
            _mockAccountServices.Setup(s => s.GetByUserName(expectedUserName)).ReturnsAsync(
                new Account() { AccountHolder = new User()
                {
                    UserName = expectedUserName
                } 
             });

            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Success);

            //Act
            Account account =await  _mockAuthenticationService.Login(expectedUserName, password);

            //Asserts
            string actualUserName = account.AccountHolder.UserName;
            Assert.AreEqual(expectedUserName, actualUserName);
        }

        [Test]
        public void Login_WithInCorrectPasswordForExistingUserName_ThrowsInvalidPasswordException()
        {
            //Arrange
            string expectedUserName = "CP";
            string password = "test";
            _mockAccountServices.Setup(s => s.GetByUserName(expectedUserName)).ReturnsAsync(
                new Account()
                {
                    AccountHolder = new User()
                    {
                        UserName = expectedUserName
                    }
                });

            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            //Act
            InvalidPasswordException invalidPasswordException = Assert.ThrowsAsync<InvalidPasswordException>(() => _mockAuthenticationService.Login(expectedUserName, password));

            //Asserts
            string actualUserName = invalidPasswordException.UserName;
            Assert.AreEqual(expectedUserName, actualUserName);
        }

        [Test]
        public void Login_NonExistingUserName__ThrowsUserNameNotFoundException()
        {
            //Arrange
            string expectedUserName = "CP";
            string password = "test";
          

            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            //Act
            UserNameNotFoundException userNameNotFoundException = Assert.ThrowsAsync<UserNameNotFoundException>(() => _mockAuthenticationService.Login(expectedUserName, password));

            //Asserts
            string actualUserName = userNameNotFoundException.UserName;
            Assert.AreEqual(expectedUserName, actualUserName);
        }

    }
}
