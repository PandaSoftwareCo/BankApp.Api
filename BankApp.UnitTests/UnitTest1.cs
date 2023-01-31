using AutoMapper;
using BankApp.Api;
using BankApp.Api.Controllers;
using BankApp.Application.Interfaces;
using BankApp.Domain.Entities;
using BankApp.Domain.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System.Net;

namespace BankApp.UnitTests
{
    public class UnitTest1
    {
        public UnitTest1()
        {

        }

        [Fact]
        public async Task TestGet()
        {
            // ARRANGE
            Account[] accounts =
            {
                new Account
                {
                    AccountId= 1,
                    AccountName = "Checking",
                    AccountNumber = "1111",
                    AccountType = AccountType.Debit
                    
                }
            };

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(r => r.Get()).Returns(accounts.ToAsyncEnumerable());
            var mapper = new Mock<IMapper>();
            var configuration = new Mock<IConfiguration>();
            var settings = new Mock<IAppSettings>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            AccountsController controller = new AccountsController(
                accountRepository.Object, 
                mapper.Object, 
                configuration.Object, 
                settings.Object, 
                new NullLogger<AccountsController>());

            // ACT
            var data = controller.Get();

            // ASSERT
            await foreach(var item in data)
            {
                Assert.NotNull(item);
            }
        }

        [Theory]
        [InlineData("api/v1/Accounts")]
        [InlineData("api/v1/Balances")]
        [InlineData("api/v1/BankTransactions")]
        [InlineData("api/v1/Categories")]
        public async Task Get_EndpointReturns(string url)
        {
        }
    }
}