using System;
using System.Collections.Generic;

namespace Sipay.Responses
{
    public class SipayRefundResponse : SipayResponseWrapper
    {
        public string order_no { get; set; }
        public string invoice_id { get; set; }
        public string ref_no { get; set; }
    }
}

