using DataLibrary.DB;
using DataLibrary.Model.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{

    public class ProductService : IProductService
    {
        private readonly IDataAccess _dataAccess;

        public ProductService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<Product> GetProductAsync(string ProductID)
        {
            return await _dataAccess.LoadSingleRowAsync<Product, dynamic>("sp_GetProduct",
                                                                                  new
                                                                                  {
                                                                                      @ProductID
                                                                                  }, ConnectionStringData.ActiveConnection);
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _dataAccess.LoadDataAsync<Product, dynamic>("sp_AllGetProducts",
                                                                                  new
                                                                                  {
                                                                                  }, ConnectionStringData.ActiveConnection);
        }
        public async Task<string> CreateProductAsync(string ProductName, string CategoryID, string ProductDescription,
                                                                        string ImagePath, decimal ProductPrice)
        {
            var created = await _dataAccess.GetSingleValueAsync<string, dynamic>("sp_CreateProduct",
                                                                                   new
                                                                                   {
                                                                                       @ProductName,
                                                                                       @ProductDescription,
                                                                                       @ImagePath,
                                                                                       @CategoryID,
                                                                                       @ProductPrice
                                                                                   }, ConnectionStringData.ActiveConnection);
            return created;
        }

    }
}
