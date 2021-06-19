using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.ApiKeys
{
    public class ApiKeyObject
    {
        public string api_key_name { get; set; }
        public string api_key_valid_until { get; set; }
        public string api_key_secret { get; set; }
        public double user_id { get; set; }
        public double api_key_id { get; set; }
        public string api_key_created_at { get; set; }
        public string api_key_updated_at { get; set; }
    }
}
