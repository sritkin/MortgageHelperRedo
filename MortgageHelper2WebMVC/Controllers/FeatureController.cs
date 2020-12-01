using MortgageHelperModels;
using MortgageHelperModels.FeatureModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MortgageHelper2WebMVC.Controllers
{
    [Authorize]
    public class FeatureController : Controller
    {
        // GET: Feature
        public ActionResult Index()
        {
            var model = new FeatureListItem[0];
            return View(model);
        }
        // GET: Feature
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeatureCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}