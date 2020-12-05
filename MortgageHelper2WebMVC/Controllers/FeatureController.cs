using Microsoft.AspNet.Identity;
using MortgageHelperData;
using MortgageHelperModels;
using MortgageHelperModels.FeatureModels;
using MortgageHelperModels.RatingModels;
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
                var rservice = CreateRatingService();

                if (service.CreateFeature(model))
                {
                // at the time a feature is created, automatically generates a rating for the property
                rservice.CreateRating(new RatingCreate { PropertyID = new ApplicationDbContext().Properties.Max(x => x.PropertyID), FeatureID = new ApplicationDbContext().Features.Max(x => x.FeatureID) });
                    return RedirectToAction("Index", "Property" );
                };

                return View(model);
            
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFeatureService();
            var detail = service.GetFeaturesByPropertyID(id);
            var model = new FeatureEdit
            {
                PropertyID = detail.PropertyID,
                FeatureID = detail.FeatureID,
                DistanceFromPopulace = detail.DistanceFromPopulace,
                RoadAccess = detail.RoadAccess,
                CityWater = detail.CityWater,
                CityElectric = detail.CityElectric,
                CitySewer = detail.CitySewer,
                Internet = detail.CitySewer,
                AlternateWater = detail.AlternateWater,
                AlternateElectric = detail.AlternateElectric,
                AlternateSewage = detail.AlternateSewage,
                BodyOfWater = detail.BodyOfWater,
                NearbyBodyOfWater = detail.NearbyBodyOfWater
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FeatureEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PropertyID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFeatureService();

            if (service.UpdateFeature(model))
            {
                TempData["SaveResult"] = "Your property's featuers were updated.";
                return RedirectToAction("Index", "Property");
            }

            ModelState.AddModelError("", "Your property's features could not be updated.");
            return View(model);
        }
        private RatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            return service;
        }
        private FeatureService CreateFeatureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FeatureService(userId);
            return service;
        }

    }
}