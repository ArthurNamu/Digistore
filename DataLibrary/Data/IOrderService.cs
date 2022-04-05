using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface IOrderService
    {
        Task<string> CreateOrderAsync(string Customer, decimal TotalValue);
        Task<string> CreateOrderListingAsync(string OrderID, string ProductID, int Quantity, decimal TotalItemPrice, decimal ProductPrice);
    }
}