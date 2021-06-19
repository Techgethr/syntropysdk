using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class AgentCoordinatesArray
    {
        public PlatformResponseErrorItem[] errors { get; set; }
        public AgentCoordinatesObject[] data { get; set; }
    }

    public class AgentCoordinatesObject
    {
        public double agent_id { get; set; }
        public double agent_location_lat { get; set; }
        public double agent_location_lon { get; set; }
    }
}
