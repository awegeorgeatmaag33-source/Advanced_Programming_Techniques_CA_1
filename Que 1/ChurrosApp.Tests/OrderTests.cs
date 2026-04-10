using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChurrosApp;

namespace ChurrosApp.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]                                                 //Using the AAA pattern (Arrange, Act and Assert)
        public void PayBill_ShouldReturnCorrectTotal()
        { 
            //Arrange Method
            Churros churros = new Churros("Coarse Sugar", 5.60);
            Order order = new Order(churros, 5);

            //Act Method
            double TotalBill = order.PayBill();

            //Assert Method
            Assert.AreEqual(28.00, TotalBill);
        }
    }
}
