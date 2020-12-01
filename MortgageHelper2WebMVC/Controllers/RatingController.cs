using MortgageHelperModels;
using MortgageHelperModels.RatingModels;
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
            var model = new RatingListItem[0];
            return View(model);
        }
        // GET: Mortgage
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}