using MortgageHelperModels;
using MortgageHelperModels.PropertyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MortgageHelper2WebMVC.Controllers
{
    [Authorize]
    public class PropertyController : Controller
    {
        
        public ActionResult Index()
        {
            var model = new PropertyListItem[0];

            return View(model);
        }
        // GET: Property
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}