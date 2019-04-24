using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using EssentialTools.Models;
using Moq;


namespace EssentialTools.Tests
{
    [TestClass]
    public class UnitTest2
    {
        private Products[] prods =
        {
            new Products{ ProductID=0, Category="Meat", Description="The covered meat", Name="Sousage", Price=239},
            new Products{ ProductID=1, Category="Milk", Description="Sour milk", Name="Kefir", Price=52},
            new Products{ ProductID=2, Category="Milk", Description="The cow's milk", Name="Milk", Price=49},
            new Products{ ProductID=3, Category="Chocolate", Description="Sweet item", Name="Snikers", Price=32}
        };

        [TestMethod]
        public void Sum_Products_Corectly()
        {
            Mock<IDiscounthelper> mock = new Mock<IDiscounthelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total );

            //var discounter = new MinimumDiscountHelper();

            var target = new LinqValueCalculator(mock.Object);
            var goalTotal = prods.Sum(e => e.Price);

            var result = target.ValueProducts(prods);

            Assert.AreEqual(goalTotal, result);
        }

        private Products[] createProduct(decimal value)
        {
            return new[] { new Products { Price = value } };
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Pass_Through_Variable_Discounts()
        {
            Mock<IDiscounthelper> mock = new Mock<IDiscounthelper>();

            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v == 0))).Throws<System.ArgumentOutOfRangeException>();
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100))).Returns<decimal>(total => (total * 0.9M));
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive))).Returns<decimal>(total => (total - 5));

            var target = new LinqValueCalculator(mock.Object);

            decimal FiveDollaesDiscount = target.ValueProducts(createProduct(5));
            decimal TenDollarsDiscount = target.ValueProducts(createProduct(10));
            decimal FiftyDollarsDiscount = target.ValueProducts(createProduct(50));
            decimal HundredDollarsDiscount = target.ValueProducts(createProduct(100));
            decimal FiveHundredDolarsDiscount = target.ValueProducts(createProduct(500));

            Assert.AreEqual(5, FiveDollaesDiscount, "5$ Fail");
            Assert.AreEqual(5, TenDollarsDiscount, "10$ Fail");
            Assert.AreEqual(45, FiftyDollarsDiscount, "50$ Fail");
            Assert.AreEqual(95, HundredDollarsDiscount, "100$ Fail");
            Assert.AreEqual(450, FiveHundredDolarsDiscount, "500$ Fail");
            target.ValueProducts(createProduct(0));
        }
    }
}
