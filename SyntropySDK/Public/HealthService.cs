using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Public
{
    public class HealthService
    {
        private HealthService()
        {

        }
        public static HttpStatusCode Get()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                var response = client.GetAsync("api/public/health").Result;
                return response.StatusCode;

                
            }
        }
    }
}
