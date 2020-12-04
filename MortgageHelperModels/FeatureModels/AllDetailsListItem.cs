using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHelperModels.FeatureModels
{
    public class AllDetailsListItem
    {
        public string Address { get; set; }
        public double Size { get; set; }
        public decimal Price { get; set; }
        public string Seller { get; set; }
        public DateTimeOffset? TimeOnMarket { get; set; }
        public string PropertyType { get; set; }
        public int FeatureID { get; set; }
        public int PropertyID { get; set; }
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
