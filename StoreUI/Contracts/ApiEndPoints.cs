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
             public static class Identity
        {
            public const string GetAll =  "user/";
            public const string Login = "user/login";
            public const string Register = "user/register";
        }
        public static class Product
        {
            public const string GetAll = "product";
            public const string Get =  "product/{ProductID}";
            public const string Create =  "Product";
        }
        public static class Order
        {
            public const string GetAll = "order/";
            public const string Get = "order/{orderID}";
            public const string Create =  "order/";
        }
    }
}
