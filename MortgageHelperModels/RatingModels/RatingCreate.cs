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
        public decimal RatingActual { get; set; }

        public decimal Price { get; set; }
        public decimal DistanceFromPopulace { get; set; }
        public bool RoadAccess { get; set; }
        public bool CityWater { get; set; }
        public bool CityElectric { get; set; }
        public bool CitySewer { get; set; }
        public bool Internet { get; set; }
        public bool AlternateWater { get; set; }
        public bool AlternateElectric { get; set; }
        public bool AlternateSewage { get; set; }
        public bool BodyOfWater { get; set; }
        public bool NearbyBodyOfWater { get; set; }

    }
}
