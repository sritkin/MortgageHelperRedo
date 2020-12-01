using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHelperData
{
    public class Rating
    {
        [Key]
        public int RatingID { get; set; }
        [Required]
        public int PropertyID { get; set; }
        public virtual Property Property { get; set; }
        public int? FeatureID { get; set; }
        public virtual Feature Feature { get; set; }
        public decimal RatingTally { get; set; }
        public decimal RatingActual { get; set; }
    }

}
