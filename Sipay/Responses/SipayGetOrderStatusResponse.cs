using System;
using System.Collections.Generic;

namespace Sipay.Responses
{
    public class SipayGetOrderStatusResponse : SipayResponseWrapper
    {
        public string transaction_status { get; set; }
        public string order_id { get; set; }
        public string reason { get; set; }
        public string bank_status_code { get; set; }
        public string bank_status_description { get; set; }
        public string ref_number { get; set; }
        public string recurring_id { get; set; }
        public string recurring_plan_code { get; set; }
        public string next_action_date { get; set; }
        public string recurring_status { get; set; }
       

    }
}

