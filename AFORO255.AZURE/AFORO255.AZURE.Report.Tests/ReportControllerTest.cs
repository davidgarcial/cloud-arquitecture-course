using AFORO255.AZURE.Report.Controllers;
using AFORO255.AZURE.Report.Models;
using AFORO255.AZURE.Report.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AFORO255.AZURE.Report.Tests
{
    [TestClass]
    public class ReportControllerTest
    {

        //IConfiguration configuration;
        //MongoRepository<Movement> mongoRepository;
        //ReportController reportController;
        public ReportControllerTest()
        {
            //configuration = new ConfigurationBuilder()
            //                 .AddJsonFile("appsettings.json")
            //                 .Build();
            //mongoRepository = new MongoRepository<Movement>(configuration);
            //reportController = new ReportController(mongoRepository);
        }


        [TestMethod]
        public void TryGetByIdRetunsOk()
        {
            //var result = reportController.GetById(2);

            //Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }

        [TestMethod]
        public void TryGetByIdRetunsNoFound()
        {
            //var result = reportController.GetById(9999999);

            //Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, typeof(NotFoundResult));

        }

    }
}
