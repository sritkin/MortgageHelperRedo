using Microsoft.AspNet.Identity;
using MortgageHelperData;
using MortgageHelperModels;
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
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index()
        {
            var service = CreateRatingService();
            var model = service.GetRatings();

            return View(model);
        }

        private RatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            return service;
        }
    }
}