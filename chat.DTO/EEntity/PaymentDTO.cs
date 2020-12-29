using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.DTO.EEntity
{
   public class PaymentDTO
    {
        public int ID { get; set; }

        public int CustomerId { get; set; }

        public string OrderId { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}
