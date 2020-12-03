using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHelperModels.FeatureModels
{
    public class FeatureEdit
    {
        public int FeatureID { get; set; }
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
