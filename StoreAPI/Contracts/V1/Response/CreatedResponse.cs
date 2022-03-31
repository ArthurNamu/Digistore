using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Contracts.V1.Response
{
    public class CreatedResponse
    {
        public bool Sucess { get; set; }
        public string CreatedID { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
