using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class NetworkObjectResponse
    {
        public NetworkObject data { get; set; }
        public PlatformResponseErrorItem[] errors { get; set; }
    }

    public class NetworkObject
    {
        public double user_id { get; set; }
        public string network_name { get; set; }
        public string network_key { get; set; }
        public NetworkMetadata network_metadata { get; set; }
    }
}
