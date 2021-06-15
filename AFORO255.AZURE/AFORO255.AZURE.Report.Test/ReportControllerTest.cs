using AFORO255.AZURE.Report.Controllers;
using AFORO255.AZURE.Report.Models;
using AFORO255.AZURE.Report.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AFORO255.AZURE.Report.Test
{
    [TestClass]
    public class ReportControllerTest
    {
        IConfiguration configuration;
        MongoRepository<Movement>mongoRepository;
        ReportController reportController;

        public ReportControllerTest()
        {
            configuration = new ConfigurationBuilder()
                             .AddJsonFile("appsettings.json")
                             .Build();
            mongoRepository = new MongoRepository<Movement>(configuration);
            reportController = new ReportController(mongoRepository);
        }

        [TestMethod]
        public void TryGetReturnsOk()
        {
            var result = reportController.GetById(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void TryGetReturnsNotFound()
        {
            var result = reportController.GetById(99999);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
