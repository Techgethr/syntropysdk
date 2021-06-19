using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Auth
{
    public class AccessTokenReadData
    {
        public string access_token_name { get; set; }
        public string access_token_expiration { get; set; }
        public string access_token_description { get; set; }
        public string access_token_id { get; set; }
    }
}
