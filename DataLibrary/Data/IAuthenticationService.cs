using DataLibrary.Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface IAuthenticationService
    {
        Task<bool> UserExistsAsync(string UserName);
        Task<bool> IsValidUserAsync(string UserName, string Password);
        Task<bool> CreateUserAsync(string UserName, string Password);
        bool UserExists(string UserName);
    }
}
