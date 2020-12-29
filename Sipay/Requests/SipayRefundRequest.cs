using Sipay.Models;
using System;
using System.Collections.Generic;

namespace Sipay.Requests
{
    public class SipayRefundRequest
    {
        public string AppID { private get; set; }
        public string AppSecret { private get; set; }
        public string MerchantKey { private get; set; }

        public decimal Amount { private get; set; }
        public string InvoiceId { private get; set; }

        public string app_id { get { return this.AppID; } }
        public string app_secret { get { return this.AppSecret; } }
        public string merchant_key { get { return this.MerchantKey; } }
        public string amount { get { return Amount.ToString("0.00").Replace(",", "."); } }
        public string invoice_id { get { return this.InvoiceId; } }

        public SipayRefundRequest(Settings settings)
        {

            this.AppID = settings.AppID;
            this.AppSecret = settings.AppSecret;
            this.MerchantKey = settings.MerchantKey;

        }

    }
}

