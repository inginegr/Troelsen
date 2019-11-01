using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication9.Controllers.Interface
{
    public class InterfaceController : Controller
    {
        // GET: Interface
        public ActionResult Index()
        {
            return View();
        }

        // GET: Interface/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Interface/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Interface/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Interface/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Interface/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Interface/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Interface/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
