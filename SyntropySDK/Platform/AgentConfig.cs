using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class AgentConfig
    {
        public PlatformResponseErrorItem errors { get; set; }
        public AdminAgentConfig data {get;set;}
    }

    public class AdminAgentConfig
    {
        public double agent_id { get; set; }
        public WgCallableObject[] vpn { get; set; }
    }

    public class WgCallableObject
    {
        public string fn { get; set; }
        public WgCallableObjectArgs args { get; set; }
        public WgCallableObjectMetadata metadata { get; set; }
    }

    public class WgCallableObjectArgs
    {
        public double endpoint_port { get; set; }
        public string endpoint_ipv4 { get; set; }
        public string[] allowed_ips { get; set; }
        public string public_key { get; set; }
        public string ifname { get; set; }
        public string gw_ipv4 { get; set; }
        public double listen_port { get; set; }
        public string internal_ip { get; set; }
    }

    public class WgCallableObjectMetadata
    {
        public double user_id { get; set; }
        public string link_tag { get; set; }
        public double agent_id { get; set; }
        public double connection_id { get; set; }
        public string device_public_ipv4 { get; set; }
        public string device_name { get; set; }
        public string device_id { get; set; }
        public WgCallableObjectIpsInfo[] allowed_ips_info { get; set; }
    }

    public class WgCallableObjectIpsInfo
    {
        public string agent_service_subnet_ip { get; set; }
        public double[] agent_service_udp_ports { get; set; }
        public double[] agent_service_tcp_ports { get; set; }
        public string agent_service_name { get; set; }
    }
}
