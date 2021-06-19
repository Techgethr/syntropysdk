using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class AgentArray
    {
        public PlatformResponseErrorItem[] errors { get; set; }
        public AgentObject[] data { get; set; }
    }

    public class AgentObject
    {
        public bool agent_services_default_status { get; set; }
        public double api_key_id { get; set; }
        public string agent_public_ipv4 { get; set; }
        public double agent_location_lat { get; set; }
        public double agent_location_lon { get; set; }
        public double agent_provider_id { get; set; }

        public string agent_location_city { get; set; }

        public string agent_location_country { get; set; }

        public string agent_device_id { get; set; }
        public string agent_name { get; set; }
        public string agent_status { get; set; }
        public string agent_version { get; set; }
        public string agent_modified_at { get; set; }
        public bool agent_is_virtual { get; set; }
        public bool agent_is_online { get; set; }
        public string agent_type { get; set; }
        public AgentLockedFields agent_locked_fields { get; set; }

    }

    public class AgentLockedFields
    {
        public bool agent_location_country { get; set; }
        public bool agent_location_city { get; set; }
        public bool agent_location_lat { get; set; }
        public bool agent_location_lon { get; set; }
        public bool agent_provider_name { get; set; }
        public bool agent_name { get; set; }
        public string[] agent_tags { get; set; }
    }
}
