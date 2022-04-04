using DataLibrary.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class OrderService : IOrderService
    {
        private readonly IDataAccess _dataAccess;
        public OrderService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<string> CreateOrderAsync(
            string ProductID, string Customer, string TotalValue, int Quantity, decimal TotalItemPrice, decimal ProductPrice)
        {
            var OrderID = await _dataAccess.GetSingleValueAsync<string, dynamic>("sp_CreateOrder",
                                                                                   new
                                                                                   {
                                                                                       @TotalValue,
                                                                                       @Customer
                                                                                   }, ConnectionStringData.ActiveConnection);
            if (!string.IsNullOrEmpty(OrderID))
            {
                OrderID = await _dataAccess.GetSingleValueAsync<string, dynamic>("sp_CreateOrderListing",
                                                                             new
                                                                             {
                                                                                 @OrderID,
                                                                                 @ProductID,
                                                                                 @Quantity,
                                                                                 @ProductPrice,
                                                                                 @TotalItemPrice
                                                                             }, ConnectionStringData.ActiveConnection);
            }
            return OrderID;
        }
    }
}
