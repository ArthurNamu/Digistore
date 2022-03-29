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

            //TODO:
            /*UserExists was closing the connection throwing an error during create user*/

            //var userExists =  _authenticationService.UserExists(UserName); 
            //if (userExists)
            //{
            //    return new AuthenticationResult
            //    {
            //        Errors = new[] { "User with this email already exists" }
            //    };
            //}

            var userCreated = await _authenticationService.CreateUserAsync(UserName, EncryptText(UserName, Password));

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
            var userExists = await _authenticationService.IsValidUserAsync(UserName, EncryptText(UserName, Password));
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
        public string EncryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
    }
}
