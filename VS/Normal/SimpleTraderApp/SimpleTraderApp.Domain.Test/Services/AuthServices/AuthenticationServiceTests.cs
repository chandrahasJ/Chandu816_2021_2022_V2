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

        [Test]
        public async Task Register_WithPasswordNotMatching__RetursPasswordDoesNotMatch()
        {
            //Arrange 
            RegisterResult expectedResult = RegisterResult.PasswordDoNotMatch;
            string password = "test";
            string confirmPassword = "test1";

            //Act 
            RegisterResult actualResult = await  _mockAuthenticationService.Register(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    password,
                    confirmPassword
                );

            //Asserts
            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        public async Task Register_WithExistingEmailId__RetursEmailAlreadyExists()
        {
            //Arrange 
            RegisterResult expectedResult = RegisterResult.EmailAlreadyExists;
            string email = "test@gmail.com";
            _mockAccountServices.Setup(x => x.GetByEmailId(email)).ReturnsAsync(new Account());

            //Act 
            RegisterResult actualResult = await _mockAuthenticationService.Register(
                    email,
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()
                );

            //Asserts
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task Register_WithExistingUserName__RetursUserNameAlreadyExists()
        {
            //Arrange 
            RegisterResult expectedResult = RegisterResult.UserNameAlreadyExists;
            string userName = "test@gmail.com";
            _mockAccountServices.Setup(x => x.GetByUserName(userName)).ReturnsAsync(new Account());

            //Act 
            RegisterResult actualResult = await _mockAuthenticationService.Register(
                    It.IsAny<string>(),
                    userName,
                    It.IsAny<string>(),
                    It.IsAny<string>()
                );

            //Asserts
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task Register_WithNonExistingUserNameAndPassword__RetursSuccess()
        {
            //Arrange 
            RegisterResult expectedResult = RegisterResult.Success;
 
            //Act 
            RegisterResult actualResult = await _mockAuthenticationService.Register(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()
                );

            //Asserts
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
