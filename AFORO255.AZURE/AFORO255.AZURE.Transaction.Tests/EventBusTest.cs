using AFORO255.AZURE.Transaction.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AFORO255.AZURE.Transaction.Tests
{
    [TestClass]
    public class EventBusTest
    {

        Mock<IEventBus> mockBus;
        public EventBusTest()
        {
            mockBus = new Mock<IEventBus>();
        }

        [TestMethod]
        public void TrySendBusOk()
        {
            //mockBus.Setup(c => c.PublishMessage(It.IsAny<object>())).ReturnsAsync(true);
            //Assert.IsTrue(mockBus.Object.PublishMessage(null).Result);
        }

        [TestMethod]
        public void TrySendBusError()
        {
            //mockBus.Setup(c => c.PublishMessage(It.IsAny<object>())).ReturnsAsync(false);
            //Assert.IsFalse(mockBus.Object.PublishMessage(null).Result);
        }

    }
}
