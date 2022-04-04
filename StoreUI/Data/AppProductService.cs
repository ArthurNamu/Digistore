using Newtonsoft.Json;
using StoreUI.Domain;
using StoreUI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace StoreUI.Data
{
    public class AppProductService : IAppProductService
    {
        public HttpClient _httpClient { get; }
        private readonly ILocalStorageService _localStorageService;
        public AppProductService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "BlazorServer");
           // httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }
        public async Task<List<ProductModel>> ListProducts()
        {
         var requestMessage = new HttpRequestMessage(HttpMethod.Get, ApiEndPoints.Product.GetAll);

            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(requestMessage);

            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<List<ProductModel>>(responseBody));
            }
            else
                return null;



        }
    }
}
