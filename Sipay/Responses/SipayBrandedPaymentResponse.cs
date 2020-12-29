using System;
using System.Collections.Generic;

namespace Sipay.Responses
{
    public class SipayBrandedPaymentResponse : SipayResponseWrapper
    {
        public string link { get; set; }
    }
}

