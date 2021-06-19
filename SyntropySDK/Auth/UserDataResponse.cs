using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntropySDK.Auth
{
    public class UserDataResponse
    {
        public double user_id { get; set; }
        public string user_email { get; set; }
        public string[] user_scopes { get; set; }

        public UserSettingsObject user_settings { get; set; }
    }

    public class UserSettingsObject
    {
        public bool show_onboarding { get; set; }
        public bool show_registration_form { get; set; }
        public string user_timezone { get; set; }
        public bool network_disable_sdn_connections { get; set; }
        public bool two_factors_authentication { get; set; }
        public string[] auth_sources { get; set; }
    }
}
