using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class ConnectionCreationBodyP2p
    {
        public AgentsPairObject agent_ids { get; set; }
        public double[] network_ids { get; set; }
        public string network_update_by { get; set; }
    }

    public class AgentsPairObject
    {
        public int agent_1_id { get; set; }
        public int agent_2_id { get; set; }
    }
}
