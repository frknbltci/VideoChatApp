using Sipay.Models;
using System;
using System.Collections.Generic;

namespace Sipay.Requests
{
    public class SipayTokenRequest
    {
        public string AppID { private get; set; }
        public string AppSecret { private get; set; }
        internal string MerchantKey { private get; set; }

        public string app_id { get { return this.AppID; }  }
        public string app_secret { get { return this.AppSecret; } }
       
    }
}
