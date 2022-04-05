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

        public async Task<string> CreateOrderAsync(string Customer, decimal TotalValue)
        {
            var OrderID = await _dataAccess.GetSingleValueAsync<string, dynamic>("sp_CreateOrder",
                                                                                   new
                                                                                   {
                                                                                       @TotalValue,
                                                                                       @Customer
                                                                                   }, ConnectionStringData.ActiveConnection);
            return OrderID;
        }
        public async Task<string> CreateOrderListingAsync(string OrderID, string ProductID, int Quantity, decimal TotalItemPrice, decimal ProductPrice)
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
            return OrderID;
        }

    }
}
