using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.ApiKeys
{
    public class ApiKeyService
    {
        private ApiKeyService()
        {

        }

        public static ApiResponse_ApiKeyObject Create(string api_key_name, string api_key_valid_until)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (string.IsNullOrWhiteSpace(api_key_name))
            {
                throw new ArgumentNullException(api_key_name);
            }
            if (string.IsNullOrWhiteSpace(api_key_valid_until))
            {
                throw new ArgumentNullException(api_key_valid_until);
            }
            using (var client = new HttpClient())
            {
                var dataObject = new { api_key_name = api_key_name, api_key_valid_until = api_key_valid_until };
                var json = JsonConvert.SerializeObject(dataObject);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("auth/api-key", dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<ApiResponse_ApiKeyObject>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static ApiResponse_ApiKeyArray Get(int? skip, int? take, string order, string filter)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            string filters = string.Empty;
            if(skip.HasValue)
            {
                filters = "skip=" + skip;
            }
            if (take.HasValue)
            {
                filters = (!string.IsNullOrWhiteSpace(filters) ? filters+"&":""  )+ "take=" + take;
            }
            if (!string.IsNullOrWhiteSpace(order))
            {
                filters = (!string.IsNullOrWhiteSpace(filters) ? filters + "&" : "") + "order=" + order;
            }
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filters = (!string.IsNullOrWhiteSpace(filters) ? filters + "&" : "") + "filter=" + filter;
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.GetAsync("auth/api-key"+(!string.IsNullOrWhiteSpace(filters)? "?"+filters:"")).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<ApiResponse_ApiKeyArray>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static void Delete(int api_key_id)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.DeleteAsync("auth/api-key/"+api_key_id).Result;

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
