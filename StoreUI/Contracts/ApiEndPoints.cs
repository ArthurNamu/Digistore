using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreUI.Contracts
{
    public class ApiEndPoints
    {
        private readonly IConfiguration _config;
        public const string Version = "v1";
        public const string Root = "api";
        public const string Base = "/" + Root + "/" + Version;
        public ApiEndPoints(IConfiguration config)
        {
            _config = config;
        }

        public static class Identity
        {
            public const string GetAll = Base + "/users/";
            public const string Login = Base + "/user/login";
            public const string Register = Base + "/user/register";
        }
    }
}
