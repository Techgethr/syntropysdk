using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Auth
{
    public class AuthorizationService
    {
        private AuthorizationService()
        {

        }
        public static void Logout()
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("auth/authorization/logout", null).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static AzureUserTokenDto AccessTokenGetLogin(string access_token)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (string.IsNullOrWhiteSpace(access_token))
            {
                throw new ArgumentNullException(access_token);
            }
            using (var client = new HttpClient())
            {
                var dataObject = new { access_token = access_token };
                var json = JsonConvert.SerializeObject(dataObject);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("auth/authorization/access-token/login", dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<AzureUserTokenDto>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static AccessTokenData AccessTokenCreateScope(string[] permissions,string access_token_expiration, string access_token_name, string access_token_description)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (string.IsNullOrWhiteSpace(access_token_expiration))
            {
                throw new ArgumentNullException(access_token_expiration);
            }
            if (string.IsNullOrWhiteSpace(access_token_name))
            {
                throw new ArgumentNullException(access_token_name);
            }
            if (string.IsNullOrWhiteSpace(access_token_description))
            {
                throw new ArgumentNullException(access_token_description);
            }
            using (var client = new HttpClient())
            {
                var dataObject = new { permissions = permissions, access_token_expiration = access_token_expiration, access_token_name= access_token_name, access_token_description= access_token_description };
                var json = JsonConvert.SerializeObject(dataObject);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("auth/authorization/access-token", dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<AccessTokenData>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }


        public static AccessTokenReadData[] GetAccessToken(int? skip, int? take, string order)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            string filters = string.Empty;
            if (skip.HasValue)
            {
                filters = "skip=" + skip;
            }
            if (take.HasValue)
            {
                filters = (!string.IsNullOrWhiteSpace(filters) ? filters + "&" : "") + "take=" + take;
            }
            if (!string.IsNullOrWhiteSpace(order))
            {
                filters = (!string.IsNullOrWhiteSpace(filters) ? filters + "&" : "") + "order=" + order;
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.GetAsync("auth/authorization/access-token" + (!string.IsNullOrWhiteSpace(filters) ? "?" + filters : "")).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<AccessTokenReadData[]>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }


        public static void DeleteAccessToken(string id)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(id);
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.DeleteAsync("auth/authorization/access-token/" + id).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }


        public static PermissionObject[] GetPermissions()
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.GetAsync("auth/authorization/permissions/access-token").Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<PermissionObject[]>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static UserDataResponse GetUser()
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.GetAsync("auth/authorization/user").Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<UserDataResponse>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }


    }
}
