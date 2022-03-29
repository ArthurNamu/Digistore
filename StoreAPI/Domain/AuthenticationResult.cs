using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Domain
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool Sucess { get; set; }
        public IEnumerable <string> Errors { get; set; }
    }
}
