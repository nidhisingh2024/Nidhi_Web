using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_2_MVC.Controllers;
using Test_2_MVC.Models;

namespace Test_2_MVC.Controllers

{
    public class CodeController : Controller
    {

        static NorthwindEntities1  db = new NorthwindEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GermanCustomers()
        {
            var germanCustomers = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(germanCustomers);
        }

        public ActionResult CustomerWithOrderID()
        {
            var CustWithID = db.Customers.Where(c => c.Orders.Any(o => o.OrderID == 10248)).FirstOrDefault();
            if (CustWithID == null)
            {
                return HttpNotFound();
            }
            return View(CustWithID);
        }
    }
}