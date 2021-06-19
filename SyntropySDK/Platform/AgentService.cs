using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class AgentService
    {
        private AgentService()
        {

        }

        public static AgentProviderArray GetAgentProviders(int? skip, int? take, string order)
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
                var response = client.GetAsync("api/platform/agent-providers" + (!string.IsNullOrWhiteSpace(filters) ? "?" + filters : "")).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<AgentProviderArray>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }


        public static SingleAgentProviderObject GetAgentProvider(int id)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.GetAsync("api/platform/agent-providers/" + id).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<SingleAgentProviderObject>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static AgentConfig GetAgentConfiguration(int id)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.GetAsync("api/platform/agent/" + id+ "config").Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<AgentConfig>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static string GetAgentWireGuardConfiguration(int id)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.GetAsync("api/platform/agent/" + id + "wg-config").Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }


        public static AgentArray GetAgents(int? skip, int? take, string order, string filter, bool loadrelations, bool showlogsstate)
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
            filters = (!string.IsNullOrWhiteSpace(filters) ? filters + "&" : "") + "load-relations=" + loadrelations;
            filters = (!string.IsNullOrWhiteSpace(filters) ? filters + "&" : "") + "show-logs-state=" + showlogsstate;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.GetAsync("api/platform/agents" + (!string.IsNullOrWhiteSpace(filters) ? "?" + filters : "")).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<AgentArray>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }


        public static AgentServiceArray GetAgentServices(int[] agentIds)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (agentIds == null || !agentIds.Any())
            {
                throw new ArgumentException("agentIds");
            }
            string filters = string.Empty;
            foreach(var agent in agentIds)
            {
                filters = (!string.IsNullOrWhiteSpace(filters) ? filters + "&" : "") + "agent-ids=" + agent;
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.GetAsync("api/platform/agent-services" + (!string.IsNullOrWhiteSpace(filters) ? "?" + filters : "")).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<AgentServiceArray>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }



        public static AgentFiltersArray GetAgentsByFilters(string filter)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            string filters = string.Empty;
            
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filters = "filter=" + filter;
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.GetAsync("api/platform/agents/filters" + (!string.IsNullOrWhiteSpace(filters) ? "?" + filters : "")).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<AgentFiltersArray>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }


        public static AgentTagArray GetAgentTags()
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.GetAsync("api/platform/agent-tags").Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<AgentTagArray>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }


        public static AgentCoordinatesArray GetAgentCoordinates(int[] agentIds)
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
                var dataObject = new { agentIds = agentIds};
                var json = JsonConvert.SerializeObject(dataObject);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("api/platform/agents/coordinates", dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<AgentCoordinatesArray>(result);
                    return resultData;
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }


        public static void UpdateStatus(UpdateStatusObject statusObject)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (statusObject == null)
            {
                throw new ArgumentNullException("statusObject");
            }
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(statusObject);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("api/platform/agent-services-subnets", dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }


        public static void DeleteAgentServices(AgentServiceId[] agent_id)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (agent_id == null || !agent_id.Any())
            {
                throw new ArgumentNullException("agent_id");
            }
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(agent_id);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("api/platform/agents/remove", dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                }
                else
                {
                    throw new Exception("Response code error: " + response.StatusCode);
                }
            }
        }

        public static CreateAgentResponse CreateAgent(CreateAgentObject agentObject)
        {
            if (string.IsNullOrWhiteSpace(SyntropyConfigurator.Jwt) || string.IsNullOrWhiteSpace(SyntropyConfigurator.BaseUrl))
            {
                throw new Exception("SyntropyConfigurator not initialized.");
            }
            if (agentObject == null)
            {
                throw new ArgumentNullException("agentObject");
            }
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(agentObject);
                var dataRequest = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", SyntropyConfigurator.Jwt);
                var response = client.PostAsync("api/platform/agents", dataRequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var resultData = JsonConvert.DeserializeObject<CreateAgentResponse>(result);
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
