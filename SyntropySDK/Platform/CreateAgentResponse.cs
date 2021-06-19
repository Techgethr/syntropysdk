using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class CreateAgentResponse
    {
        public CreateAgentObject data { get; set; }
        public PlatformResponseErrorItem[] errors { get; set; }
    }
}
