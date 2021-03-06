﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHelperModels.PropertyModels
{
    public class PropertyCreate
    {

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
