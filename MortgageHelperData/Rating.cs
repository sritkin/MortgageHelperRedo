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
    public class RatingScore
    {
        [Key]
        public int RatingID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        public int? PropertyID { get; set; }
        [ForeignKey(nameof(PropertyID))]
        public virtual Property Property { get; set; }
        public int? FeatureID { get; set; }
        [ForeignKey(nameof(FeatureID))]
        public virtual Feature Feature { get; set; }
        public decimal Rating { get; set; }
    }

}
