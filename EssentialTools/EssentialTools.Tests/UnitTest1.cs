using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;


namespace EssentialTools.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscounthelper GetTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            IDiscounthelper target = GetTestObject();
            decimal total = 200;

            var discountedTotal = target.ApplyDiscount(total);

            Assert.AreEqual(total * 0.9M, discountedTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            IDiscounthelper target = GetTestObject();

            decimal TenDollarsDiscount = target.ApplyDiscount(10);
            decimal HundredDollarsDiscount = target.ApplyDiscount(100);
            decimal FiftyDollarsDiscount = target.ApplyDiscount(50);

            Assert.AreEqual(5, TenDollarsDiscount, "$10 discount is wrong");
            Assert.AreEqual(95, HundredDollarsDiscount, "$100 discount is wrong");
            Assert.AreEqual(45, FiftyDollarsDiscount, "$50 discount is wrong");
        }

        [TestMethod]
        public void Discount_Less_Than_10()
        {
            IDiscounthelper target = GetTestObject();

            decimal discount5 = target.ApplyDiscount(5);
            decimal discount0 = target.ApplyDiscount(0);

            Assert.AreEqual(0, discount0);
            Assert.AreEqual(0, discount0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_Total()
        {
            IDiscounthelper target = GetTestObject();

            target.ApplyDiscount(-1);
        }
    }
}
