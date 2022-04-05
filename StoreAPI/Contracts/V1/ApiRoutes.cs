using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Contracts.V1
{
   public static class ApiRoutes
    {
        public const string Version = "v1";
        public const string Root = "api";
        public const string Base  = "/"+ Root +"/"+ Version;
        public static class Identity
        {
            public const string GetAll = Base + "/user/";
            public const string Login = Base + "/user/login";
            public const string Register = Base + "/user/register";
         }
        public static class Product
        {
            public const string GetAll = Base + "/product/";
            public const string Get = Base + "/product/{ProductID}";
            public const string Create = Base + "/Product";
        }
        public static class Order
        {
            public const string GetAll = Base + "/order/";
            public const string Get = Base + "/order/{orderID}";
            public const string Create = Base + "/order";
        }
    }
}
