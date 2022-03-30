using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StoreUI.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var userName = await _sessionStorage.GetItemAsync<string>("userName");
            var accessToken = ""; //= await _localStorageService.GetItemAsync<string>("accessToken");
            ClaimsIdentity identity;
            if (userName != null)
            {
                identity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, userName),
                }, "apiauth_type");
            }
            else
            {
                identity = new ClaimsIdentity();
            }
                    
             var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public void MarkUserAsAuthenticated(string userName)
        {
            ClaimsIdentity identity = new ClaimsIdentity(new[]
{
                new Claim(ClaimTypes.Name, userName),
            }, "apiauth_type");
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
        public void MarkUserAsLoggedOut()
        {
            _sessionStorage.RemoveItemAsync("userName");
            ClaimsIdentity identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
