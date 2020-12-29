using Newtonsoft.Json;
using Sipay.Models;
using Sipay.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Sipay.Requests
{
    public class SipayBrandedPaymentRequest
    {
        public Settings _settings { get; set; }

        public string CurrencyCode { private get; set; }
        public Invoice Invoice { private get; set; }
        public string Name { private get; set; }
        public string SurName { private get; set; }

        public string currency_code { get { return this.CurrencyCode; } }
        public Invoice invoice { get { return this.Invoice; } }
        public string name { get { return this.Name; } }
        public string surname { get { return this.SurName; } }

        public SipayBrandedPaymentRequest(Settings settings)
        {
            this._settings = settings;
        }

    }

    public class Invoice
    {
        public List<Item> Items { get; set; }
        public string InvoiceId { private get; set; }
        public string InvoiceDescription { private get; set; }
        public decimal Total { private get; set; }
        public string Discount { private get; set; }
        public string Coupon { private get; set; }
        public string ReturnUrl { private get; set; }
        public string CancelUrl { private get; set; }
        public string BillingAddress1 { private get; set; }
        public string BillingAddress2 { private get; set; }
        public string BillingCity { private get; set; }
        public string BillingPostcode { private get; set; }
        public string BillingState { private get; set; }
        public string BillingCountry { private get; set; }
        public string BillingEmail { private get; set; }
        public string BillingPhone { private get; set; }

        public bool IsRecurringPayment { private get; set; }
        public int RecurringPaymentNumber { private get; set; }
        public string RecurringPaymentCycle { private get; set; }
        public int RecurringPaymentInterval { private get; set; }
        public string RecurringWebhookKey { private get; set; }



        public List<Item> items { get { return this.Items; } }
        public string invoice_id { get { return this.InvoiceId; } }
        public string invoice_description { get { return this.InvoiceDescription; } }
        public decimal total { get { return Total; } }
        public string return_url { get { return this.ReturnUrl; } }
        public string cancel_url { get { return this.CancelUrl; } }
        public string discount { get { return this.Discount; } }
        public string coupon { get { return this.Coupon; } }
        public string bill_address1 { get { return this.BillingAddress1; } }
        public string bill_address2 { get { return this.BillingAddress2; } }
        public string bill_city { get { return this.BillingCity; } }
        public string bill_postcode { get { return this.BillingPostcode; } }
        public string bill_state { get { return this.BillingState; } }
        public string bill_country { get { return this.BillingCountry; } }
        public string bill_email { get { return this.BillingEmail; } }
        public string bill_phone { get { return this.BillingPhone; } }

        public int order_type { get { return this.IsRecurringPayment ? 1 : 0; } }
        public int recurring_payment_number { get { return this.RecurringPaymentNumber; } }
        public string recurring_payment_cycle { get { return this.RecurringPaymentCycle; } }
        public int recurring_payment_interval { get { return this.RecurringPaymentInterval; } }
        public string recurring_web_hook_key { get { return this.RecurringWebhookKey; } }



        public Invoice()
        {
            this.Items = new List<Item>();

        }
    }
}
