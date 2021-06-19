using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class LogTimestampObject
    {
        public int logs_read_timestamp_entity_id { get; set; }
        public string logs_read_timestamp_entity_type { get; set; }
        public string logs_read_timestamp_last_read_timestamp { get; set; }
    }
}
