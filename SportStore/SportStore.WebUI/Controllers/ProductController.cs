using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;


namespace SportStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;1
        public int PageSize = 4;


        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(int page=1)
        {
            return View(repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize));
        }
    }
}