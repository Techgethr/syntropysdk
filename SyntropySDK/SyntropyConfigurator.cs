using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK
{
    public class SyntropyConfigurator
    {
        internal static string Jwt { get; set; }
        internal static string BaseUrl { get; set; }

        private SyntropyConfigurator() { }
        public static void Init(string jwt, string baseUrl = "https://api.syntropystack.com/")
        {
            Jwt = jwt;
            BaseUrl = baseUrl;
            if(!BaseUrl.EndsWith("/"))
            {
                BaseUrl = BaseUrl + "/";
            }
        }
    }
}
