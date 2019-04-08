using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoLotDAL;
using AutoLotDAL.DataOperations;
using AutoLotDAL.Models;

namespace WebTroelsen.Controllers
{
    public class ProductsController : Controller
    {
        List<Products> prd = new List<Products>();
        InventoryDAL dAL = new InventoryDAL();
        // GET: Products
        public ActionResult Index()
        {
            prd = dAL.GetAllInventory();
            return View(prd);
        }
    }
}