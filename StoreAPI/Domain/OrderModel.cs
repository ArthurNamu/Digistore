using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Domain
{
    public class OrderModel
    {
        public string OrderId { get; set; }
        public string UserEmail { get; set; }
        public List<CartItemModel> CartItems { get; set; }
        public decimal OrderTotal { get; set; }
    }
}
