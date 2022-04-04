using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreUI.Contracts
{
    //TODO:
    /*Set and Fetch from configuration file*/
    public static class ApiEndPoints
    {
        public const string Version = "v1";
        public const string Root = "api";
        public const string Base = @"https://localhost:5001/" + Root + "/" + Version;
        public static class Identity
        {
            public const string GetAll = Base + "/users/";
            public const string Login = Base + "/user/login";
            public const string Register = Base + "/user/register";
        }
        public static class Product
        {
            public const string GetAll = Base + "/products/";
            public const string Get = Base + "/product/{ProductID}";
            public const string Create = Base + "/Product";
        }
    }
}
