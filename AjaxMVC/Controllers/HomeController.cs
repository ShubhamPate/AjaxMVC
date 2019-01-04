using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxMVC.Models;
using System.Threading;

namespace AjaxMVC.Controllers
{
    public class HomeController : Controller
    {
        DemoDbEntities db = new DemoDbEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult OrderById()
        {
            Thread.Sleep(5000);
            List<tblProduct> products = db.tblProducts.OrderBy(x => x.ProductId).ToList();
            return PartialView("_Grid",products);
        }
        public PartialViewResult OrderByName()
        {
            Thread.Sleep(5000);
            List<tblProduct> products = db.tblProducts.OrderBy(x => x.Name).ToList();
            return PartialView("_Grid", products);
        }
        public PartialViewResult OrderByPrice()
        {
            Thread.Sleep(5000);
            List<tblProduct> products = db.tblProducts.OrderBy(x => x.Price).ToList();
            return PartialView("_Grid", products);
        }

        public ViewResult Register()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult Register(string txtName)
        {
            TempData["uname"] = txtName;
            return PartialView("Details");
        }
    }
}