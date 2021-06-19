using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class ConnectionService
    {
        private ConnectionService() { }

        public static void RemoveConnection(string networkupdatedby, RemoveConnectionObject[] connectionObjects)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (connectionObjects == null || !connectionObjects.Any())
            {
                throw new ArgumentNullException("connectionObjects");
            }
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(connectionObjects);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("api/platform/connections/remove?network-updated-by=" + networkupdatedby, dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static void RemoveAgentConnection(RemoveAgentConnectionObject[] connectionObjects)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (connectionObjects == null || !connectionObjects.Any())
            {
                throw new ArgumentNullException("connectionObjects");
            }
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(connectionObjects);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("/api/platform/connections/agents/remove", dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static void DeleteAgentConnection(double[] connectionSubnetIds)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (connectionSubnetIds == null || !connectionSubnetIds.Any())
            {
                throw new ArgumentNullException("connectionSubnetIds");
            }
            using (var client = new HttpClient())
            {
                var dataObject = new { connectionSubnetIds = connectionSubnetIds };
                var json = JsonConvert.SerializeObject(dataObject);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("api/platform/connection-services-delete", dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static void UpdateAgentConnection(UpdateAgentConnectionRequest updateAgentConnection)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (updateAgentConnection == null)
            {
                throw new ArgumentNullException("updateAgentConnection");
            }
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(updateAgentConnection);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("/api/platform/connection-services", dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static ConnectionArray GetConnections(int[] connectionIds)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (connectionIds == null || !connectionIds.Any())
            {
                throw new ArgumentException("connectionIds");
            }
            string filters = string.Empty;
            foreach (var conn in connectionIds)
            {
                filters = (!string.IsNullOrWhiteSpace(filters) ? filters + "&" : "") + "connection-ids=" + conn;
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.GetAsync("api/platform/connection-services" + (!string.IsNullOrWhiteSpace(filters) ? "?" + filters : "")).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<ConnectionArray>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static ConnectionArray GetConnections(int? skip, int? take, string order, string filter, string showSdnConnections, bool loadRelations)
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
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filters = (!string.IsNullOrWhiteSpace(filters) ? filters + "&" : "") + "filter=" + filter;
            }
            if (!string.IsNullOrWhiteSpace(showSdnConnections))
            {
                filters = (!string.IsNullOrWhiteSpace(filters) ? filters + "&" : "") + "show-sdn-connections=" + showSdnConnections;
            }
            filters = (!string.IsNullOrWhiteSpace(filters) ? filters + "&" : "") + "load-relations=" + loadRelations;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.GetAsync("/api/platform/connections" + (!string.IsNullOrWhiteSpace(filters) ? "?" + filters : "")).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<ConnectionArray>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }


        public static ConnectionArray PointToPoint(string[] paths, ConnectionCreationBodyP2p body)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (paths == null || !paths.Any())
            {
                throw new ArgumentException("paths");
            }
            if(body == null)
            {
                throw new ArgumentException("body");
            }
            string filters = string.Empty;
            foreach (var path in paths)
            {
                filters = (!string.IsNullOrWhiteSpace(filters) ? filters + "&" : "") + "paths=" + path;
            }
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(body);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("api/platform/connections/point-to-point" + (!string.IsNullOrWhiteSpace(filters) ? "?" + filters : ""), dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<ConnectionArray>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }


        public static ConnectionArray Mesh(string[] paths, ConnectionCreationBodyMesh mesh)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (paths == null || !paths.Any())
            {
                throw new ArgumentException("paths");
            }
            if (mesh == null)
            {
                throw new ArgumentException("mesh");
            }
            string filters = string.Empty;
            foreach (var path in paths)
            {
                filters = (!string.IsNullOrWhiteSpace(filters) ? filters + "&" : "") + "paths=" + path;
            }
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(mesh);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("api/platform/connections/mesh" + (!string.IsNullOrWhiteSpace(filters) ? "?" + filters : ""), dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<ConnectionArray>(result);
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
