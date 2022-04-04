using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface IOrderService
    {
        Task<string> CreateOrderAsync(string ProductID, string Customer, string TotalValue, int Quantity, decimal TotalItemPrice, decimal ProductPrice);
    }
}