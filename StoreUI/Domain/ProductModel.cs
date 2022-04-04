using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreUI.Domain
{
    public class ProductModel
    {
        public string ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        public string CategoryID { get; set; }
    }
}
