using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class AgentFiltersArray
    {
        public AgentFiltersObject data { get; set; }
        public PlatformResponseErrorItem[] errors { get; set; }
    }

    public class AgentFiltersObject
    {
        public TsoaPick_AgentNameId[] agentNames { get; set; }
        public TsoaPick_AgentVersion[] versions { get; set; }
        public TsoaPick_AgentLocation[] countries { get; set; }
    }

    public class TsoaPick_AgentNameId
    {
        public double agent_id { get; set; }
        public string agent_name { get; set; }
    }

    public class TsoaPick_AgentVersion
    {
        public string agent_version { get; set; }
    }

    public class TsoaPick_AgentLocation
    {
        public string agent_location_country { get; set; }
    }
}
