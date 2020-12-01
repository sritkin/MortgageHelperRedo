using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHelperData
{
    public class Property
    {
        [Key]
        public int PropertyID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public double Size { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Seller { get; set; }
        [Required]
        public DateTimeOffset? TimeOnMarket { get; set; }
        [Required]
        public string PropertyType { get; set; }
    }


}
