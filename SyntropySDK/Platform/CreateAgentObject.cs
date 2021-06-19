using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class CreateAgentObject
    {
        public string agent_provider_name { get; set; }
        public string[] agent_tags { get; set; }
        public bool agent_services_default_status { get; set; }
        public string api_key { get; set; }
        public string agent_public_ipv4 { get; set; }
        public float agent_location_lat { get; set; }
        public float agent_location_lon { get; set; }
        public string agent_location_city { get; set; }
        public string agent_location_country { get; set; }
        public string agent_device_id { get; set; }
        public string agent_name { get; set; }
        public string agent_status { get; set; }
        public string agent_version { get; set; }
        public int agent_provider_id { get; set; }
        public bool agent_is_online { get; set; }
        public string agent_modified_at { get; set; }
        public bool agent_is_virtual { get; set; }

        public AgentLockedFields agent_locked_fields { get; set; }
        public AgentInterfacesMetadata network { get; set; }
    }

    public class AgentInterfacesMetadata
    {
        public AgentInterfaceMetadata PUBLIC { get; set; }
        public AgentInterfaceMetadata SDN1 { get; set; }
        public AgentInterfaceMetadata SDN2 { get; set; }
        public AgentInterfaceMetadata SDN3 { get; set; }
    }

    public class AgentInterfaceMetadata
    {
        public string agent_interface_public_key { get; set; }
        public string agent_interface_endpoint_ipv4 { get; set; }
        public int agent_interface_endpoint_port { get; set; }
    }
}
