using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class AgentServiceArray
    {
        public PlatformResponseErrorItem[] errors { get; set; }
        public AgentServiceObject[] data { get; set; }
    }

    public class AgentServiceObject
    {
        public double agent_service_id { get; set; }
        public double agent_id { get; set; }
        public double[] agent_service_tcp_ports { get; set; }
        public double[] agent_service_udp_ports { get; set; }
        public string agent_service_name { get; set; }
        public string agent_service_type { get; set; }
        public string agent_service_networks { get; set; }
        public bool agent_service_is_active { get; set; }
        public bool agent_service_is_enabled_by_default { get; set; }
    }
}
