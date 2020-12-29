using Sipay.Models;
using System;
using System.Collections.Generic;

namespace Sipay.Requests
{
    public class SipayGetPosRequest
    {
        public string CreditCardNo { private get; set; }
        public decimal Amount { private get; set; }
        public string CurrencyCode { private get; set; }
        public string MerchantKey { private get; set; }
        public bool IsRecurring { private get; set; }

        public string credit_card { get { return this.CreditCardNo; } }
        public string amount { get { return Amount.ToString("0.00").Replace(",", "."); } }
        public string currency_code { get { return this.CurrencyCode; } }
        public string merchant_key { get { return this.MerchantKey; } }
        public int is_recurring { get { return this.IsRecurring ? 1 : 0; } }

    }
}
