﻿using MortgageHelperModels;
using MortgageHelperModels.PropertyModels;
using MortgageHelperServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MortgageHelper2WebMVC.Controllers
{
    [Authorize]
    public class PropertyController : Controller
    {
        
        public ActionResult Index()
        {
            var service = CreatePropertyService();
            var model = service.GetProperties();

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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreatePropertyService();

            if (service.CreateProperty(model))
            {
                return RedirectToAction("Create", "Feature");
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateFeatureService();
            var model = service.GetAllDetailsByPropertyID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePropertyService();
            var detail = service.GetPropertyByID(id);
            var model = new PropertyEdit
                {
                    PropertyID = detail.PropertyID,
                    Address = detail.Address,
                    Size = detail.Size,
                    Price = detail.Price,
                    Seller = detail.Seller,
                    TimeOnMarket = detail.TimeOnMarket,
                    PropertyType = detail.PropertyType
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PropertyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PropertyID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePropertyService();

            if (service.UpdateProperty(model))
            {
                TempData["SaveResult"] = "Your property was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your property could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreatePropertyService();
            var model = service.GetPropertyByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProperty(int id)
        {
            var service = CreatePropertyService();
            var fservice = CreateFeatureService();
            var rservice = CreateRatingService();
            rservice.DeleteAllRatingsGivenPropertyID(id);
            fservice.DeleteAllFeaturesGivenPropertyID(id);
            service.DeleteProperty(id);
            //feature service deletefeature
            //ratingservice delete rating
            TempData["SaveResult"] = "Your property was deleted";

            return RedirectToAction("Index");
        }

        private PropertyService CreatePropertyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PropertyService(userId);
            return service;
        }

        private FeatureService CreateFeatureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FeatureService(userId);
            return service;
        }
        private RatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            return service;
        }
    }
}