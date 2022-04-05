using Blazored.LocalStorage;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StoreUI.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;

namespace StoreUI.Data
{
    /// <summary>
    /// This will make all HTTP related calls across the store
    /// </summary>
    public class DigiShopService<T> : IDigiShopService<T>
    {
        private readonly ILocalStorageService _localStorageService;
        public HttpClient _httpClient { get; }
        private readonly EmailConfigs _emailSettings;
        private readonly EndPointsConfig _endpoint;
        public DigiShopService(HttpClient httpClient, ILocalStorageService localStorageService
            , IOptions<EmailConfigs> emailSettings, IOptions<EndPointsConfig> endpoint)
        {
            _endpoint = endpoint.Value;
            _emailSettings = emailSettings.Value;
            _localStorageService = localStorageService;
            httpClient.BaseAddress = new Uri(_endpoint.StoreBaseAddress);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "BlazorServer");
            _httpClient = httpClient;
        }
        public async Task<List<T>> GetAllAsync(string requestUri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);

           // var token = await _localStorageService.GetItemAsync<string>("accessToken");
            //requestMessage.Headers.Authorization
            //    = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;

            if (responseStatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<List<T>>(responseBody));
            }
            else
                return null;
        }
        public async Task<T> GetByIdAsync(string requestUri, int Id)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri + Id);

            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            return await Task.FromResult(JsonConvert.DeserializeObject<T>(responseBody));
        }

        public async Task<T> SaveAsync(string requestUri, T obj)
        {
            string serializedUser = JsonConvert.SerializeObject(obj);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);

            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedObj = JsonConvert.DeserializeObject<T>(responseBody);

            return await Task.FromResult(returnedObj);
        }

        public  async Task<bool> EmailOrderAsync(string emailBody)
        {
            var mailMessage = new MailMessage(_emailSettings.EmailFrom, _emailSettings.EmailTo);
            mailMessage.Subject = "Order";
            mailMessage.Body = emailBody;
            var smtpClient = new SmtpClient(_emailSettings.SmtpClient, _emailSettings.SmtpPort);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = _emailSettings.EmailUserName,
                Password = _emailSettings.EmailPassword
            };
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
            return await Task.FromResult(true);

        }
    }
}
