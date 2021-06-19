using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class ConnectionCreationBodyMesh
    {
        public AgentsObject agent_ids { get; set; }
        public double[] network_ids { get; set; }
        public string network_update_by { get; set; }
    }

    public class AgentsObject
    {
        public int agent_id { get; set; }
    }
}
