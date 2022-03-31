using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Model.Store
{
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImagePath { get; set; }
        public decimal ProductPrice { get; set; }
        public string CategoryID { get; set; }
    }
}
