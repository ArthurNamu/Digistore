using DataLibrary.DB;
using DataLibrary.Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IDataAccess _dataAccess;

        public AuthenticationService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<bool> UserExistsAsync(string UserName)
        {
            return await _dataAccess.ExecuteFunctionAsync<bool, dynamic>("SELECT [dbo].[fn_UserNameExists] (@UserName)",
                                                                                  new
                                                                                  {
                                                                                      @UserName,
                                                                                  }, ConnectionStringData.ActiveConnection);
        }
        public bool UserExists(string UserName)
        {
            return  _dataAccess.GetSingleValue<bool, dynamic>($"sp_UserExists",
                                                                                  new
                                                                                  {
                                                                                      @UserName,
                                                                                  }, ConnectionStringData.ActiveConnection);
        }

        public async Task<bool> IsValidUserAsync(string UserName, string Password)
        {
            return await _dataAccess.ExecuteFunctionAsync<bool, dynamic>($"SELECT [dbo].[fn_IsValidUser] (@UserName, @Password)",
                                                                                  new
                                                                                  {
                                                                                      @UserName ,
                                                                                      @Password 
                                                                                  }, ConnectionStringData.ActiveConnection);
        }
        public async Task<bool> CreateUserAsync(string UserName, string Password)
        {
             await _dataAccess.SaveDataAsync<dynamic>("sp_RegisterUser",
                                                                                  new
                                                                                  {
                                                                                      @UserName ,
                                                                                      @Password
                                                                                    }, ConnectionStringData.ActiveConnection);
            return true;
        }
    }
}
