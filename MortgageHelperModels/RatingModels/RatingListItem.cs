using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHelperModels
{
    public class RatingListItem
    {
        public int RatingID { get; set; }
        public int PropertyID { get; set; }
        public int? FeatureID { get; set; }
        public decimal RatingTally { get; set; }
        public decimal RatingActual { get; set; }
    }
}
