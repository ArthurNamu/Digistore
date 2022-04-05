using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StoreUI.Contracts;
using StoreUI.Domain;
using StoreUI.Options;
using StoreUI.UtilEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StoreUI.Data
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        //TODO: 
        /*
        Refactor code on register and login calls, Use the same code
        Work on a better salt creation
        */
        public HttpClient _httpClient { get; }
        private readonly EndPointsConfig _endpoint;
        public UserAuthenticationService(HttpClient httpClient, IOptions<EndPointsConfig> endpoints)
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "BlazorServer");
            _endpoint = endpoints.Value;
            httpClient.BaseAddress = new Uri(_endpoint.StoreBaseAddress);
            _httpClient = httpClient;
        }
        public async Task<UserAuthResponse> LoginAsync(UserModel user)
        {
            var EncryptionSalt = "RandomSalt";
            user.Password = Utility.EncryptText(EncryptionSalt, user.Password); //
            string serializedUser = JsonConvert.SerializeObject(user);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, ApiEndPoints.Identity.Login);
            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var authResponse = JsonConvert.DeserializeObject<UserAuthResponse>(responseBody);

            if (responseStatusCode == System.Net.HttpStatusCode.OK)
                authResponse.IsSuccess = true;
            authResponse.ResponseCode = responseStatusCode.ToString();
            authResponse.UserName = user.UserName;

            return await Task.FromResult(authResponse);
        }

        public async Task<UserAuthResponse> RegisterUserAsync(UserModel user)
        {
            //TODO: 
            //Work on a better salt creation
            var EncryptionSalt = "RandomSalt";
            user.Password = Utility.EncryptText(EncryptionSalt, user.Password); //
            string serializedUser = JsonConvert.SerializeObject(user);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, ApiEndPoints.Identity.Register);
            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var authResponse = JsonConvert.DeserializeObject<UserAuthResponse>(responseBody);
            if (responseStatusCode == System.Net.HttpStatusCode.OK)
                authResponse.IsSuccess = true;
            authResponse.ResponseCode = responseStatusCode.ToString();
            authResponse.UserName = user.UserName;

            return await Task.FromResult(authResponse);
        }
    }
}
