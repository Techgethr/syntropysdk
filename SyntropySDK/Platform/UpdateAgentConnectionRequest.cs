using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class UpdateAgentConnectionRequest
    {
        public int connectionId { get; set; }
        public UpdateAgentConnectionRequestChange[] changes { get; set; }
    }

    public class UpdateAgentConnectionRequestChange
    {
        public int agentServiceSubnetId { get; set; }
        public bool isEnabled { get; set; }
    }
}
