using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StoreAPI;
using StoreAPI.Contracts.V1;
using StoreAPI.Contracts.V1.Requests;
using StoreAPI.Contracts.V1.Response;
using StoreAPI.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Test_StoreAPI_IntegrationTest
{
    public class IntegrationTest
    {
        protected readonly HttpClient _client;
        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
            .WithWebHostBuilder(builder =>
             {
                 builder.ConfigureServices(services =>
                 {
                 });
             });
            _client = appFactory.CreateClient();
            _client.DefaultRequestHeaders
         .Accept  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected async Task AuthenticateAsync()
        {
            
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }
        protected async Task<ProductModel> CreateProductAsync(ProductModel request)
        {
            string serializedProduct = JsonConvert.SerializeObject(request);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, ApiRoutes.Product.Create);
            requestMessage.Content = new StringContent(serializedProduct);
            requestMessage.Content.Headers.ContentType
                = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(requestMessage);
            return JsonConvert.DeserializeObject<ProductModel>(await response.Content.ReadAsStringAsync());
           // return await response.Content.ReadAsAsync<ProductModel>();
        }

        protected async Task<string> GetJwtAsync()
        {
            string serializedUser = JsonConvert.SerializeObject(new LoginRequest
            {
                UserName = "an@nj.com",
                Password = "4kDYlBGZPdXSD9Tf4x/HQg=="
            });

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, ApiRoutes.Identity.Login);
            requestMessage.Content = new StringContent(serializedUser);
            requestMessage.Content.Headers.ContentType
                = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(requestMessage);

            var registrationResponse = JsonConvert.DeserializeObject<AuthSuccessResponse>(await response.Content.ReadAsStringAsync());
            return registrationResponse.Token;
        }
    }
}
