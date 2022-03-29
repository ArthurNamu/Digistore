using StoreAPI.Contracts.V1.Requests;
using StoreAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> CreateAsync(string @UserName, string @Password);
        Task<AuthenticationResult> LoginAsync(string @UserName, string @Password);
    }
}
