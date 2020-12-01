using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHelperData
{
    public class Mortgage
    {
        [Key]
        public int MortgageID { get; set; }
        [Required]
        public int PropertyID { get; set; }
        public virtual Property Property { get; set; }
        public decimal Zero { get; set; }
        public decimal Five { get; set; }
        public decimal Ten { get; set; }
        public decimal Fifteen { get; set; }
        public decimal Twenty { get; set; }
        public decimal TwentyFive { get; set; }
        public decimal Thirty { get; set; }
        public decimal ThirtyFive { get; set; }
        public decimal Forty { get; set; }
        public decimal FortyFive { get; set; }
        public decimal Fifty { get; set; }
        public decimal FiftyFive { get; set; }
        public decimal Sixty { get; set; }
        public decimal SixtyFive { get; set; }
        public decimal Seventy { get; set; }
        public decimal SeventyFive { get; set; }
        public decimal Eighty { get; set; }
        public decimal EightyFive { get; set; }
        public decimal Ninety { get; set; }
        public decimal NinetyFive { get; set; }

    }

}
