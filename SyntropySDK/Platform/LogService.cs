using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class LogService
    {
        private LogService()
        {

        }

        public static void SaveLogsTimestamp(LogTimestampObject[] timestampObject)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (timestampObject == null)
            {
                throw new ArgumentNullException("timestampObject");
            }
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(timestampObject);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("api/platform/logs-reads-timestamp", dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }
    }
}
