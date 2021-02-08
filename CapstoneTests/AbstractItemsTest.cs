using Capstone.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class AbstractItemsTest
    {
        [DataTestMethod]
        [DataRow("Snickers",2.00,5)]
        [DataRow("Butter Fingers",2.89,1)]
        [DataRow("M&Ms",1.75,0)]
        public void CandyTest(string productName, double price, int quantity)
        {
            decimal priceM = (decimal)price;
            AbstractItems ai = new Candy(productName, priceM,quantity);

            Assert.IsNotNull(ai);
            Assert.AreEqual(productName, ai.ProductName);
            Assert.AreEqual(priceM, ai.Price);
            Assert.AreEqual(quantity, ai.Quantity);
            Assert.AreEqual("Munch Munch, Yum!", ai.Message);
        }

        [DataTestMethod]
        [DataRow("Doritos", 2.00, 5)]
        [DataRow("Funyuns", 2.89, 1)]
        [DataRow("Cheetos", 1.75, 0)]
        public void ChipTest(string productName, double price, int quantity)
        {
            decimal priceM = (decimal)price;
            AbstractItems ai = new Chip(productName, priceM, quantity);

            Assert.IsNotNull(ai);
            Assert.AreEqual(productName, ai.ProductName);
            Assert.AreEqual(priceM, ai.Price);
            Assert.AreEqual(quantity, ai.Quantity);
            Assert.AreEqual("Crunch Crunch, Yum!", ai.Message);
        }

        [DataTestMethod]
        [DataRow("Pepsi", 2.00, 5)]
        [DataRow("Mt.Dew", 2.89, 1)]
        [DataRow("KickStart", 1.75, 0)]
        public void DrinkTest(string productName, double price, int quantity)
        {
            decimal priceM = (decimal)price;
            AbstractItems ai = new Drink(productName, priceM, quantity);

            Assert.IsNotNull(ai);
            Assert.AreEqual(productName, ai.ProductName);
            Assert.AreEqual(priceM, ai.Price);
            Assert.AreEqual(quantity, ai.Quantity);
            Assert.AreEqual("Glug Glug, Yum!", ai.Message);
        }

        [DataTestMethod]
        [DataRow("5", 2.00, 5)]
        [DataRow("Cool Mint", 2.89, 1)]
        [DataRow("Spear Mint", 1.75, 0)]
        public void GumTest(string productName, double price, int quantity)
        {
            decimal priceM = (decimal)price;
            AbstractItems ai = new Gum(productName, priceM, quantity);

            Assert.IsNotNull(ai);
            Assert.AreEqual(productName, ai.ProductName);
            Assert.AreEqual(priceM, ai.Price);
            Assert.AreEqual(quantity, ai.Quantity);
            Assert.AreEqual("Chew Chew, Yum!", ai.Message);
        }
    }
}
