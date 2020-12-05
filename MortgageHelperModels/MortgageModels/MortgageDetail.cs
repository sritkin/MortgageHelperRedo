using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHelperModels.MortgageModels
{
    public class MortgageDetail
    {
        public int? PropertyID { get; set; }
        public decimal Interest { get; set; }
        public int Period { get; set; }
        public decimal Payment { get; set; }
        public decimal TotalLoanAmount { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal Price { get; set; }
    }
}
