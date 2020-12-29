using chat.CORE.Entities;
using chat.DTO.EEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.SERVICES.Interfaces
{
   public interface IPaymentService
    {
        bool insertPayment(PaymentDTO gelen);

        Payment getPayment(string OrderId);

        bool updatePayment(PaymentDTO gelen);

    }
}
