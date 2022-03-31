using StoreUI.Contracts;
using StoreUI.Domain;
using System.Net.Http;
using System.Threading.Tasks;

namespace StoreUI.Data
{
    public interface IUserAuthenticationService
    {
        HttpClient _httpClient { get; }

        Task<UserAuthResponse> LoginAsync(UserModel user);
        Task<UserAuthResponse> RegisterUserAsync(UserModel user);
    }
}