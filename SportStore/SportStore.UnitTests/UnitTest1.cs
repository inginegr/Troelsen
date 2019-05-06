﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.WebUI.Controllers;
using System.Web.Mvc;
using SportStore.WebUI.Models;
using SportStore.WebUI.HtmlHelpers;



namespace SportStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Filter_Product()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID=1, Name="P1", Category="Cat1"},
                new Product{ProductID=2, Name="P2", Category="Cat2"},
                new Product{ProductID=3, Name="P3", Category="Cat1"},
                new Product{ProductID=4, Name="P4", Category="Cat2"},
                new Product{ProductID=5, Name="P5", Category="Cat3"}
            });

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            Product[] result = ((ProductsListViewModel)controller.List("Cat2", 1).Model).Products.ToArray();

            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].Name == "P2" && result[0].Category == "Cat2");
            Assert.IsTrue(result[1].Name == "P4" && result[1].Category == "Cat2");
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
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

            ProductsListViewModel result = (ProductsListViewModel)contr.List(null, 2).Model;
            PagingInfo pagingInfo = result.PagingInfo;

            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
            Assert.AreEqual(pagingInfo.TotalItems, 5);
            Assert.AreEqual(pagingInfo.TotalPages, 2);
        }

        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID=1, Name="P1"},
                new Product{ProductID=2, Name="P2"},
                new Product{ProductID=3, Name="P3"},
                new Product{ProductID=4, Name="P4"},
                new Product{ProductID=5, Name="P5"}
            });

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            Product[] productsArray = result.Products.ToArray();
            Assert.IsTrue(productsArray.Length == 2);
            Assert.AreEqual(productsArray[0].Name, "P4");
            Assert.AreEqual(productsArray[1].Name, "P5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo { CurrentPage = 2, TotalItems = 28, ItemsPerPage = 10 };
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>" +
                @"<a class=""btn btn-default btn-primary btn btn-default"" href=""Page2"">2</a>" +
                @"<a class=""btn btn-default"" href=""Page3"">3</a>", result.ToString());
        }

    }
}