using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Domain
{
    public class CartItem : ProductModel
    {
        public int Quantity { get; set; }
        public decimal ItemTotal { get; set; }
        public string UserName { get; set; }
    }
}
