using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class NetworkAgentPayload
    {
        public int agent_id { get; set; }
        public double? network_agent_coord_x { get; set; }
        public double? network_agent_coord_y { get; set; }
    }
}
