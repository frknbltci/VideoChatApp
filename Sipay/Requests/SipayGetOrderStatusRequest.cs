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
    public class SipayGetOrderStatusRequest
    {
        public Settings _settings { get; set; }

        public string InvoiceId { private get; set; }

        public string invoice_id { get { return this.InvoiceId; } }

        public SipayGetOrderStatusRequest(Settings settings)
        {
            this._settings = settings;
        }

    }

}
