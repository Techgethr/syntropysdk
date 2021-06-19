using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class SingleAgentProviderObject
    {
        public AgentProviderObject data { get; set; }
        public PlatformResponseErrorItem[] errors { get; set; }
    }
}
