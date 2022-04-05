using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreUI.Options
{
    public  class EmailConfigs
    {
        public  string EmailTo { get; set; }
        public string EmailFrom { get; set; }
        public string SmtpClient { get; set; }
        public int SmtpPort { get; set; }
        public string EmailUserName { get; set; }
        public string EmailPassword { get; set; }
    }
}
