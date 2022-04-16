using Microsoft.AspNetCore.Mvc.Testing;
using StoreAPI;
using StoreAPI.Contracts.V1;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Test_StoreAPI_IntegrationTest
{
    public class UnitTest1
    {
        private readonly HttpClient _client;
        public UnitTest1()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }
        [Fact]
        public async Task Test1()
        {
            var response = await _client.GetAsync(ApiRoutes.Product.GetAll);
        }
    }
}
