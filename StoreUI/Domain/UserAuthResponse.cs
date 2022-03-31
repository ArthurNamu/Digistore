using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreUI.Domain
{
    public class UserAuthResponse
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string ResponseCode { get; set; }
        public IEnumerable<string> Errors { get; set; }

    }
}
