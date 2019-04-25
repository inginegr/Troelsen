using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.WebUI.Controllers;
using System.Web.Mvc;



namespace SportStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product { ProductID=1, Name="P1" },
                new Product { ProductID=2, Name="P2" },
                new Product { ProductID=3, Name="P3" },
                new Product { ProductID=4, Name="P4" },
                new Product { ProductID=5, Name="P5" }
            });

            ProductController contr = new ProductController(mock.Object);
            contr.PageSize = 3;

            IEnumerable<Product> res = (IEnumerable<Product>)contr.List(2).Model;

            Product[] prodArray = res.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }
    }
}
