using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay.Models
{
    public enum PaymentType : int
    {
        WhiteLabel2D = 0,
        WhiteLabel2DOr3D = 1,
        WhiteLabel3D = 2,
        BrandedPayment = 4
    }
}
