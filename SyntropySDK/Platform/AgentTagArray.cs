using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class AgentTagArray
    {
        public AgentTagObject[] data { get; set; }
        public PlatformResponseErrorItem[] errors { get; set; }
    }

    public class AgentTagObject
    {
        public string agent_tag_name { get; set; }
        public double user_id { get; set; }
    }
}
