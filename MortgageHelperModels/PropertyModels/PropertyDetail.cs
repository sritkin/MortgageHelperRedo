using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHelperModels.PropertyModels
{
    public class PropertyDetail
    {
        public int PropertyID { get; set; }
        public string Address { get; set; }
        public double Size { get; set; }
        public decimal Price { get; set; }
        public string Seller { get; set; }
        public DateTimeOffset? TimeOnMarket { get; set; }
        public string PropertyType { get; set; }
    }
}
