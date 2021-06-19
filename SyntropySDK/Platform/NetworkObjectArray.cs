using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class NetworkObjectArray
    {
        public PlatformResponseErrorItem[] errors { get; set; }
        public NetworkObject[] data { get; set; }
    }
}
