using System;
using System.Collections.Generic;

namespace Sipay.Responses
{
    public class SipayGetPosResponse : SipayResponseWrapper
    {
        public SipayGetPosResponse()
        {
            Data = new List<PosData>();
        }

        public List<PosData> Data { get; set; }
    }

    public class PosData
    {
        public string pos_id { get; set; }
        public string campaign_id { get; set; }
        public string allocation_id { get; set; }
        public int installments_number { get; set; }

        //public string cot_percentage { get; set; }
        //public string cot_fixed { get; set; }
        public decimal amount_to_be_paid { get; set; }
        public string currency_code { get; set; }
        public string currency_id { get; set; }
        public string title { get; set; }

        public string hash_key { get; set; }

    }

}

