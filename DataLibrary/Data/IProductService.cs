using DataLibrary.Model.Store;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface IProductService
    {
        Task<string> CreateProductAsync(string ProductName, string CategoryID, string ProductDescription, string ImagePath, decimal ProductPrice);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(string ProductID);
    }
}