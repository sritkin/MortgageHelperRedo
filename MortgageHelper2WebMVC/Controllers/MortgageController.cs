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
        public ActionResult MortgageCalculator(int id)
        {
            
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MortgageCalculator(MortgageDetail model, int id)
        {
            var svc = CreateMortgageService();
            //add new mortgage object to database with necessary properties provided by user
            svc.CreateMortgage(model, id);
            //get mortgage object that was just made
            var detail = svc.GetMortgageByPropertyID(id);
            //This section is where I convert the formulas for calculating a mortgage into code. While PEMDAS logic remains constant, the formula requires use of ^ which means something different in this language than in mathematics. To resolve this I created multiple variables to break up the formulas calculations into smaller portions. I've included the formulas below to make it easier to follow the logic. 
            /*M = monthly payment, P = principal, I = interest, N = number of payments, R = monthly interest rate
             */
            
            //interest rate comes in at values above for apr, needs to be /12 for monthly and /100 to convert to proper format
            decimal monthlyInterestRate = detail.Interest /1200;
            //convert years to months
            decimal newPeriod = detail.Period * 12;
            double y = (double)(1 + monthlyInterestRate);
            double z = (double)newPeriod;

            decimal P = detail.Price - detail.Payment;
            double var2 = (double)(newPeriod * (-1));
            decimal x = (decimal)Math.Pow(y, z);
            decimal negx = (decimal)Math.Pow( y, var2 );

            // formula  M = P [ I(1 + I)^N ] / [ (1 + I)^N – 1]
            decimal newmonthlypayment = (P * monthlyInterestRate * x) / (x - 1);
            // formula Total Amount Paid For Loan = (R*P*N) / 1-((1+R)^-N) 
            decimal newTotalLoan = (monthlyInterestRate * P * newPeriod) / (1 - negx);
            ViewBag.ResultA = newmonthlypayment;
            ViewBag.ResultB = newTotalLoan;

            //delete mortgage object that was just added to database
            svc.DeleteAllMortgagesGivenPropertyID(id);
            return View();
        }
        private MortgageService CreateMortgageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MortgageService(userId);
            return service;
        }
    }
}