using Microsoft.AspNet.Identity;
using MortgageHelperModels;
using MortgageHelperModels.MortgageModels;
using MortgageHelperServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MortgageHelper2WebMVC.Controllers
{
    [Authorize]
    public class MortgageController : Controller
    {
        // GET: Mortgage
        public ActionResult Index()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MortgageService(userId);
            var model = service.GetMortgages();

            return View(model);
        }
        // GET: Mortgage
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MortgageCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MortgageService(userId);

            if (service.CreateMortgage(model))
            {
                return RedirectToAction("Index");
            };

            return RedirectToAction("Index");
        }
    }
}