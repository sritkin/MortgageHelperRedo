using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHelperModels.RatingModels
{
    public class RatingCreate
    {
     
        public int? PropertyID { get; set; }
        public int? FeatureID { get; set; }
        public decimal RatingTally { get; set; }
        public decimal RatingActual { get; set; }
        
    }
}
