using Blazored.LocalStorage;
using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StoreUI.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
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

            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

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

        public async Task<T> SaveListAsync(string requestUri, List<T> obj)
        {
            if (obj is null)
                throw new ArgumentNullException("Empty value can not be saved");
            if (string.IsNullOrEmpty(requestUri))
                throw new ArgumentNullException("The resource location is invalid");

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

        public  async Task<bool> EmailOrderAsync(string emailBody, string emailTo)
        {
            if (string.IsNullOrEmpty(emailBody))
                throw new ArgumentNullException("Email can not be Empty");
            if (string.IsNullOrEmpty(emailTo))
                throw new ArgumentException("Customer email is blank");

            var sender = new SmtpSender(() => new SmtpClient(_emailSettings.SmtpClient, _emailSettings.SmtpPort)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            Timeout = 10000,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_emailSettings.EmailUserName,_emailSettings.EmailPassword)
        });

            Email.DefaultSender = sender;
            var email = await Email
                .From(_emailSettings.EmailFrom)
                .To(emailTo)
                .Subject("Thanks!")
                .Body(emailBody,true)
                .SendAsync();
            return true;
            #region Other Email Implementations
            /* string senderEmail = _emailSettings.EmailFrom;
            string senderPassword = _emailSettings.EmailPassword;

            SmtpClient client = new SmtpClient( Q   );
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(senderEmail, senderPassword);

            MailMessage mailMessage = new MailMessage(senderEmail, _emailSettings.EmailTo, "Hallo", emailBody);
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = Encoding.UTF8;
            client.Send(mailMessage);
            return await Task.FromResult(true);
            //************************************************************


            var mailMessage = new MailMessage(_emailSettings.EmailFrom, _emailSettings.EmailFrom);
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
           */
            #endregion 
        }

    }
}
