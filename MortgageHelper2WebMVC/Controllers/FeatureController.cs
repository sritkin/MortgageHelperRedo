using Microsoft.AspNet.Identity;
using MortgageHelperModels;
using MortgageHelperModels.FeatureModels;
using MortgageHelperServices;
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
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FeatureService(userId);
            var model = service.GetFeatures();

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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FeatureService(userId);

            if (service.CreateFeature(model))
            {
                return RedirectToAction("Index");
            };

            return RedirectToAction("Index");
        }
    }
}