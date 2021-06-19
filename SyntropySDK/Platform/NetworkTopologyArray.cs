using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class NetworkTopologyArray
    {
        public PlatformResponseErrorItem[] errors { get; set; }
        public NetworkTopologyObject[] data { get; set; }
    }

    public class NetworkTopologyObject
    {
        public double network_id { get; set; }
        public string network_name { get; set; }
        public double network_agents_count { get; set; }
        public double network_agent_connections_count { get; set; }
    }
}
