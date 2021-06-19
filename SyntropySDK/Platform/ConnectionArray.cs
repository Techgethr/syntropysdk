using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class ConnectionArray
    {
        public PlatformResponseErrorItem[] errors { get; set; }
        public ConnectionObject[] data { get; set; }
    }

    public class ConnectionObject
    {
        public double agent_1_id { get; set; }
        public double agent_interface_1_id { get; set; }
        public double agent_2_id { get; set; }
        public double agent_interface_2_id { get; set; }
        public double user_id { get; set; }
        public double agent_sdn_policy_id { get; set; }
        public double agent_connection_tx_bytes_total { get; set; }
        public double agent_connection_rx_bytes_total { get; set; }
        public double agent_connection_latency_ms { get; set; }
        public double agent_connection_packet_loss { get; set; }
        public string agent_connection_link_tag { get; set; }
        public string agent_connection_status { get; set; }
        public string agent_connection_last_handshake { get; set; }
    }
}
