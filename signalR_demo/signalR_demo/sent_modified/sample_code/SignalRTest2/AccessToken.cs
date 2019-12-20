using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRTest2
{
    public class AccessToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string user_name { get; set; }
        public string user_descriptor { get; set; }
    }
}
