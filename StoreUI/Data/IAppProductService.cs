using StoreUI.Domain;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StoreUI.Data
{
    public interface IAppProductService
    {
        HttpClient _httpClient { get; }

        Task<List<ProductModel>> ListProducts();
    }
}