using DataLibrary.Data;
using Microsoft.IdentityModel.Tokens;
using StoreAPI.Contracts.V1.Requests;
using StoreAPI.Domain;
using StoreAPI.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StoreAPI.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly JwtSettings _jwtSettings;

        //TO DO:
        /*Rethink the password encryption procedure*/
        public IdentityService(IAuthenticationService authenticationService, JwtSettings jwtSettings)
        {
            _authenticationService = authenticationService;
            _jwtSettings = jwtSettings;
        }
        public async Task<AuthenticationResult> CreateAsync(string UserName, string Password)
        {

            var userExists = await _authenticationService.UserExistsAsync(UserName);
            if (userExists)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with this email already exists" }
                };
            }

            var userCreated = await _authenticationService.CreateUserAsync(UserName, Password);

            if (userCreated == false)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Error Creating the user" }
                };
            }
            return GenerateJwt(UserName);
         }

        public async Task<AuthenticationResult> LoginAsync(string UserName, string Password)
        {
            var userExists = await _authenticationService.IsValidUserAsync(UserName,  Password);
            if (userExists==false)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User email/Password combination is wrong" }
                };
            }
            return GenerateJwt(UserName);
        }
        private AuthenticationResult GenerateJwt(string UserName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticationResult
            {
                Sucess = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
       
    }
}
