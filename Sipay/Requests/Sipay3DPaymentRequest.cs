using Sipay.Models;
using Sipay.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Sipay.Requests
{
    public class Sipay3DPaymentRequest
    {
        public Settings _settings { get; set; }
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
        public string ReturnUrl { private get; set; }
        public string CancelUrl { private get; set; }
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


        private string pos_id { get { return this.PosId; } }
        private string cc_holder_name { get { return this.CCHolderName; } }
        private string cc_no { get { return this.CCNo; } }
        private string expiry_month { get { return this.ExpiryMonth; } }
        private string expiry_year { get { return this.ExpiryYear; } }
        private string cvv { get { return this.CCV; } }
        private string currency_id { get { return this.CurrencyId; } }
        private string currency_code { get { return this.CurrencyCode; } }
        private string campaign_id { get { return this.CampaignId; } }
        private string allocation_id { get { return this.AllocationId; } }
        private string installments_number { get { return this.InstallmentsNumber.ToString(); } }
        private string return_url { get { return this.ReturnUrl; } }
        private string cancel_url { get { return this.CancelUrl; } }
        private string invoice_id { get { return this.InvoiceId; } }
        private string invoice_description { get { return this.InvoiceDescription; } }
        private string total { get { return Total.ToString("0.00").Replace(",", "."); } }
        private string payable_amount { get { return PayableAmount.ToString("0.00").Replace(",", ".");  } }

        private List<Item> items { get { return this.Items; } }
        private string name { get { return this.Name; } }
        private string surname { get { return this.SurName; } }

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

        public Sipay3DPaymentRequest(Settings settings , PosData posData)
        {
            this._settings = settings;
            this.Items = new List<Item>();

            this.AllocationId =posData.allocation_id;
            this.CampaignId = posData.campaign_id;
            this.PosId = posData.pos_id;
            this.PayableAmount = posData.amount_to_be_paid;
            this.Total = posData.amount_to_be_paid;
            this.InstallmentsNumber = posData.installments_number;
            this.CurrencyCode = posData.currency_code;
            this.CurrencyId = posData.currency_id;
            this.HashKey = posData.hash_key;
        }

        public string GenerateFormHtmlToRedirect(string FormUrl)
        {
            StringBuilder formData = new StringBuilder();

            formData.Append("<html>");
            formData.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            formData.AppendFormat("<form name='form' action='{0}' method='post'>", FormUrl);
            //formData.AppendFormat("<input type='hidden' name='id' value='{0}'>", id);

            formData.AppendFormat("<input type='hidden' name='pos_id' value='{0}'>", this.pos_id);
            formData.AppendFormat("<input type='hidden' name='cc_holder_name' value='{0}'>", this.cc_holder_name);
            formData.AppendFormat("<input type='hidden' name='cc_no' value='{0}'>", this.cc_no);
            formData.AppendFormat("<input type='hidden' name='expiry_month' value='{0}'>", this.expiry_month);
            formData.AppendFormat("<input type='hidden' name='expiry_year' value='{0}'>", this.expiry_year);
            formData.AppendFormat("<input type='hidden' name='cvv' value='{0}'>", this.cvv);
            formData.AppendFormat("<input type='hidden' name='currency_id' value='{0}'>", this.currency_id);
            formData.AppendFormat("<input type='hidden' name='currency_code' value='{0}'>", this.currency_code);
            formData.AppendFormat("<input type='hidden' name='campaign_id' value='{0}'>", this.campaign_id);
            formData.AppendFormat("<input type='hidden' name='allocation_id' value='{0}'>", this.allocation_id);
            formData.AppendFormat("<input type='hidden' name='installments_number' value='{0}'>", this.installments_number);
            formData.AppendFormat("<input type='hidden' name='return_url' value='{0}'>", this.return_url);
            formData.AppendFormat("<input type='hidden' name='cancel_url' value='{0}'>", this.cancel_url);
            formData.AppendFormat("<input type='hidden' name='invoice_id' value='{0}'>", this.invoice_id);
            formData.AppendFormat("<input type='hidden' name='discount' value='{0}'>", this.discount);
            formData.AppendFormat("<input type='hidden' name='coupon' value='{0}'>", this.coupon);

            formData.AppendFormat("<input type='hidden' name='invoice_description' value='{0}'>", this.invoice_description);
            formData.AppendFormat("<input type='hidden' name='total' value='{0}'>", this.total);
            formData.AppendFormat("<input type='hidden' name='merchant_key' value='{0}'>", this._settings.MerchantKey);
            formData.AppendFormat("<input type='hidden' name='app_id' value='{0}'>", this._settings.AppID);
            formData.AppendFormat("<input type='hidden' name='app_secret' value='{0}'>", this._settings.AppSecret);

            formData.AppendFormat("<input type='hidden' name='payable_amount' value='{0}'>", this.payable_amount);

            string items = "[{ \"name\":\"Siparis\",\"price\":" + this.total + ",\"quantity\":1,\"description\":\"" + this.invoice_id + "\"}]";

            formData.AppendFormat("<input type='hidden' name='items' value='{0}'>", items);

            formData.AppendFormat("<input type='hidden' name='name' value='{0}'>", this.name);
            formData.AppendFormat("<input type='hidden' name='surname' value='{0}'>", this.surname);
            if (this.IsRecurringPayment)
            {
                formData.AppendFormat("<input type='hidden' name='order_type' value='{0}'>", this.order_type);
                formData.AppendFormat("<input type='hidden' name='recurring_payment_number' value='{0}'>", this.recurring_payment_number);
                formData.AppendFormat("<input type='hidden' name='recurring_payment_cycle' value='{0}'>", this.recurring_payment_cycle);
                formData.AppendFormat("<input type='hidden' name='recurring_payment_interval' value='{0}'>", this.recurring_payment_interval);
                formData.AppendFormat("<input type='hidden' name='recurring_web_hook_key' value='{0}'>", this.recurring_web_hook_key);
            }
            formData.AppendFormat("<input type='hidden' name='hash_key' value='{0}'>", this.hash_key);


            // Other params go here
            formData.AppendFormat("</form>");
            formData.AppendFormat("</body>");
            formData.AppendFormat("</html>");

            return formData.ToString();
        }

    }
}
