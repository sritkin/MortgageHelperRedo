using Microsoft.AspNet.Identity;
using MortgageHelperData;
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
            var service = CreateFeatureService();
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

                var service = CreateFeatureService();


                if (service.CreateFeature(model))
                {
                    return RedirectToAction("Create", "Rating");
                };

                return View(model);
            
        }
        private FeatureService CreateFeatureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FeatureService(userId);
            return service;
        }
    }
}