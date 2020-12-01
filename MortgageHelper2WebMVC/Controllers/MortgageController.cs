using MortgageHelperModels;
using MortgageHelperModels.MortgageModels;
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
            var model = new MortgageListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}