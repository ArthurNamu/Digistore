using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StoreUI.Data
{
    public class UserAuthenticationService
    {
        public HttpClient _httpClient { get; }
        private readonly IConfiguration _config;

        public UserAuthenticationService(HttpClient httpClient)
        {
             _config=config;
            httpClient.BaseAddress = new Uri(_config.GetSection("ApiBaseAddress").Value);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "BlazorServer");

            _httpClient = httpClient;
        }
    }
}
