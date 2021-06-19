using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class NetworkService
    {
        private NetworkService()
        {

        }


        public static NetworkObjectResponse CreateNetwork(CreateNetworkObject networkObject)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (networkObject == null)
            {
                throw new ArgumentNullException("networkObject");
            }
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(networkObject);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("api/platform/networks", dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<NetworkObjectResponse>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static NetworkObjectArray GetNetworks(int? skip, int? take, string order, string filter)
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
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.GetAsync("api/platform/networks" + (!string.IsNullOrWhiteSpace(filters) ? "?" + filters : "")).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<NetworkObjectArray>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }


        public static NetworkTopologyArray GetTopology(int networkId)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.GetAsync("api/platform/networks/topology?network_id=" + networkId).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<NetworkTopologyArray>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static void DeleteNetwork(int id)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.DeleteAsync("api/platform/networks/" + id).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {

                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static void AddAgents(int networkId, NetworkAgentPayload[] agents)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (agents == null || !agents.Any())
            {
                throw new ArgumentNullException("agents");
            }
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(agents);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("api/platform/network/"+ networkId+ "/agents/add", dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static void RemoveAgents(int networkId, int[] agentIds)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (agentIds == null || !agentIds.Any())
            {
                throw new ArgumentNullException("agentIds");
            }
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(agentIds);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("api/platform/networks/" + networkId + "/agents/remove", dataRequest).Result;

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
