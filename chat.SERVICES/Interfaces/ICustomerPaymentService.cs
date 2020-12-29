using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.SERVICES.Interfaces
{
   public interface ICustomerPaymentService
    {
        bool addCusPay(int? price,int? cusId, int? empid);
    }
}
