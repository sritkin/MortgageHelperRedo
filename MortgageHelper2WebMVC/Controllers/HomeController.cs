using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MortgageHelper2WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AddProperty()
        {
            ViewBag.Message = "Add a new property to your list.";

            return View();
        }
        public ActionResult CompareProperties()
        {
            ViewBag.Message = "Sort your current properties to see how they stack up to one another.";

            return View();
        }
    }
}