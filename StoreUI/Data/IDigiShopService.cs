using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StoreUI.Data
{
    public interface IDigiShopService<T>
    {
        HttpClient _httpClient { get; }

        Task<bool> EmailOrderAsync(string emailBody);
        Task<List<T>> GetAllAsync(string requestUri);
        Task<T> GetByIdAsync(string requestUri, int Id);
        Task<T> SaveAsync(string requestUri, T obj);
    }
}