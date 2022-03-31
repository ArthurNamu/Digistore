using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using StoreUI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StoreUI.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var accessToken = await  _localStorageService.GetItemAsync<string>("accessToken");

            ClaimsIdentity identity;
            if (string.IsNullOrEmpty(accessToken) == false)
            {
                var userName = await _localStorageService.GetItemAsync<string>("userName");
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

        public async Task MarkUserAsAuthenticated(UserAuthResponse authResponse)
        {
            await _localStorageService.SetItemAsync("userName", authResponse.UserName);
            await _localStorageService.SetItemAsync("accessToken", authResponse.Token);
            ClaimsIdentity identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, authResponse.UserName),
            }, "apiauth_type");
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
        public void MarkUserAsLoggedOut()
        {
            _localStorageService.RemoveItemAsync("userName");
            _localStorageService.RemoveItemAsync("accessToken");
            ClaimsIdentity identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
