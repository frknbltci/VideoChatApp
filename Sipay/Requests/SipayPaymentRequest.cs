using Sipay.Models;
using Sipay.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Sipay.Requests
{
    public class SipayPaymentRequest
    {
        public string AppID { private get; set; }
        public string AppSecret { private get; set; }
        public string MerchantKey { private get; set; }

        public string PosId { private get; set; }
        public string CCHolderName { private get; set; }
        public string CCNo { private get; set; }
        public string ExpiryMonth { private get; set; }
        public string ExpiryYear { private get; set; }
        public string CCV { private get; set; }
        public string CurrencyId { private get; set; }
        public string CurrencyCode { private get; set; }
        public string CampaignId { private get; set; }
        public string AllocationId { private get; set; }
        public int InstallmentsNumber { private get; set; }
        public string InvoiceId { private get; set; }
        public string InvoiceDescription { private get; set; }
        public decimal Total { private get; set; }
        public decimal PayableAmount { private get; set; }
        public string PosAmount { private get; set; }
        public string Name { private get; set; }
        public string SurName { private get; set; }
        public string Discount { private get; set; }
        public string Coupon { private get; set; }

        public List<Item> Items { get; set; }
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
        public string HashKey { private get; set; }



        public string pos_id { get { return this.PosId; } }
        public string cc_holder_name { get { return this.CCHolderName; } }
        public string cc_no { get { return this.CCNo; } }
        public string expiry_month { get { return this.ExpiryMonth; } }
        public string expiry_year { get { return this.ExpiryYear; } }
        public string cvv { get { return this.CCV; } }
        public string currency_id { get { return this.CurrencyId; } }
        public string currency_code { get { return this.CurrencyCode; } }
        public string campaign_id { get { return this.CampaignId; } }
        public string allocation_id { get { return this.AllocationId; } }
        public string installments_number { get { return this.InstallmentsNumber.ToString(); } }
        public string invoice_id { get { return this.InvoiceId; } }
        public string invoice_description { get { return this.InvoiceDescription; } }
        public string total { get { return Total.ToString("0.00").Replace(",", "."); } }
        public string payable_amount { get { return Total.ToString("0.00").Replace(",", "."); } }

        public string app_id { get { return this.AppID; } }
        public string app_secret { get { return this.AppSecret; } }
        public string merchant_key { get { return this.MerchantKey; } }

        public List<Item> items { get { return this.Items; } }

        public string return_url { get { return this.ReturnUrl; } }
        public string cancel_url { get { return this.CancelUrl; } }

        public string name { get { return this.Name; } }
        public string surname { get { return this.SurName; } }

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
        public string hash_key { get { return this.HashKey; } }


        public SipayPaymentRequest(Settings settings, PosData posData)
        {
            this.Items = new List<Item>();

            this.AppID = settings.AppID;
            this.AppSecret = settings.AppSecret;
            this.MerchantKey = settings.MerchantKey;

            this.AllocationId = posData.allocation_id;
            this.CampaignId = posData.campaign_id;
            this.PosId = posData.pos_id;
            this.PayableAmount = posData.amount_to_be_paid;
            this.Total = posData.amount_to_be_paid;
            this.InstallmentsNumber = posData.installments_number;
            this.CurrencyCode = posData.currency_code;
            this.CurrencyId = posData.currency_id;
            this.HashKey = posData.hash_key;

        }
    }
}
