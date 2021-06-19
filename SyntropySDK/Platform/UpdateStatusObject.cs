using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Platform
{
    public class UpdateStatusObject
    {
        public UpdateStatusSubnet[] subnetsToUpdate { get; set; }
    }

    public class UpdateStatusSubnet
    {
        public bool isEnabled { get; set; }
        public int id { get; set; }
    }
}
