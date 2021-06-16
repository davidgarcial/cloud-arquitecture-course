using AFORO255.AZURE.Account.Controllers;
using AFORO255.AZURE.Account.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AFORO255.AZURE.Account.Tests
{
    [TestClass]
    public class AccountControllerTest
    {
        IConfiguration configuration;
        AccountRepository accountRepository;
        AccountController accountController;

        public AccountControllerTest()
        {
            //configuration = new ConfigurationBuilder()
            //                 .AddJsonFile("appsettings.json")
            //                 .Build();
            //accountRepository = new AccountRepository(configuration);
            //accountController = new AccountController(accountRepository);
        }


        [TestMethod]
        public void TryGetReturnsOk()
        {
            //var result = accountController.Get().Result;

            //Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void TryGetReturnsError()
        {
            //var result = accountController.Get().Result;

            //Assert.IsNotNull(result);
            //Assert.IsNotInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}
