using Sipay.Models;
using Sipay.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chat.Pool.Models
{
    [Serializable]
    public partial class PaymentModel
    {
        public int CustomerId { get; set; }

        public string OrderId { get; set; }

        public decimal OrderTotal { get; set; }

        public string PaymentMethodSystemName { get; set; }

        public string CreditCardType { get; set; }

        public string CreditCardName { get; set; }

        public string CreditCardNumber { get; set; }

        public int CreditCardExpireYear { get; set; }

        public int CreditCardExpireMonth { get; set; }

        public string CreditCardCvv2 { get; set; }

        public string PurchaseOrderNumber { get; set; }

        public int InstallmentNumber { get; set; }

        public PosData SelectedPosData { get; set; }
        public PaymentType Is3D { get; set; }
        public decimal Amount { get; set; }

    }
}