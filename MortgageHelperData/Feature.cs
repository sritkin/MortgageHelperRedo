using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHelperData
{
    public class Feature
    {
        [Key]
        public int FeatureID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        public int? PropertyID { get; set; }
        [ForeignKey(nameof(PropertyID))]
        public virtual Property Property { get; set; }
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
